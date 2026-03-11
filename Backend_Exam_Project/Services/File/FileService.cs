using Backend_Exam_Project.DTOs;
using Supabase;

namespace Backend_Exam_Project.Services.File;

public class FileService(
    Client supabaseClient,
    IConfiguration configuration
) : IFileService
{
    private readonly SupabaseSettings _supabaseSettings = configuration.GetSection("Supabase").Get<SupabaseSettings>()
        ?? throw new InvalidOperationException("Supabase configuration is missing.");

    public async Task<UploadFileResultDTO> UploadFile(IFormFile file)
    {
        if (file == null || file.Length == 0)
        {
            throw new InvalidOperationException("Please provide a file to upload.");
        }

        var bucket = _supabaseSettings.Bucket;
        if (string.IsNullOrWhiteSpace(bucket))
        {
            throw new InvalidOperationException("Supabase bucket is not configured.");
        }

        await using var stream = file.OpenReadStream();
        using var memoryStream = new MemoryStream();
        await stream.CopyToAsync(memoryStream);

        var extension = Path.GetExtension(file.FileName);
        var storedFileName = $"{Guid.NewGuid():N}{extension}";
        var storagePath = $"uploads/{storedFileName}";

        await supabaseClient.Storage
            .From(bucket)
            .Upload(memoryStream.ToArray(), storagePath, new Supabase.Storage.FileOptions(), null, true);

        string? publicUrl = null;

        try
        {
            publicUrl = supabaseClient.Storage.From(bucket).GetPublicUrl(storagePath);
        }
        catch
        {
            // Ignore public URL generation for private buckets.
        }

        return new UploadFileResultDTO
        {
            Bucket = bucket,
            Path = storagePath,
            FileName = file.FileName,
            ContentType = file.ContentType,
            Size = file.Length,
            PublicUrl = publicUrl
        };
    }
}
