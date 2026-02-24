using Backend_Exam_Project.DTOs;

namespace Backend_Exam_Project.Repository.Auth;

public interface IAuthRepository
{
    Task<LoginDTO> Login(string Email);
    Task<UserInfoDTO> UserInfo(string Email);
}
