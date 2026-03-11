namespace Backend_Exam_Project.DTOs;

public class CreateTicketDTO
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Priority { get; set; } = string.Empty;
    public int? AssignedTo { get; set; }
}

public class ListTicketsDTO
{
    public int TicketID { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Priority { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public ListUsersDTO CreatedBy { get; set; } = new();
    public ListUsersDTO AssignTo { get; set; } = new();
}

public class UploadFileResultDTO
{
    public string Bucket { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty;
    public string ContentType { get; set; } = string.Empty;
    public long Size { get; set; }
    public string? PublicUrl { get; set; }
}
