using Backend_Exam_Project.DTOs;
using Backend_Exam_Project.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Exam_Project.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController(
    IAuthService authService
) : ControllerBase
{
    [HttpPost]
    [Produces<AuthResponseDTO>]
    public async Task<IActionResult> Login(LoginDTO dto)
    {
        var response = await authService.Login(dto);
        return Ok(response);
    }
}
