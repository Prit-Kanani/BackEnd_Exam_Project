using Backend_Exam_Project.DTOs;

namespace Backend_Exam_Project.Services.File;

public interface IFileService
{
    Task<UploadFileResultDTO> UploadFile(IFormFile file);
}
