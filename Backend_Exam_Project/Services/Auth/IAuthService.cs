using Backend_Exam_Project.DTOs;

namespace Backend_Exam_Project.Services.Auth;

public interface IAuthService
{
    Task<AuthResponseDTO> Login(LoginDTO login);
}

