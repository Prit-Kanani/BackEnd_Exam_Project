using Backend_Exam_Project.DTOs;
using Backend_Exam_Project.Services.File;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Exam_Project.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class FileController(
    IFileService fileService
) : ControllerBase
{
    [HttpPost("upload")]
    [Consumes("multipart/form-data")]
    [Produces<UploadFileResultDTO>]
    public async Task<IActionResult> Upload([FromForm] UploadFileRequestDTO request)
    {
        var response = await fileService.UploadFile(request.File);
        return Ok(response);
    }
}
