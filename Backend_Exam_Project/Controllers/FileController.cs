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
    [Produces<UploadFileResultDTO>]
    public async Task<IActionResult> Upload([FromForm] IFormFile file)
    {
        var response = await fileService.UploadFile(file);
        return Ok(response);
    }
}
