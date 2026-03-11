using Backend_Exam_Project.Data;
using Backend_Exam_Project.DTOs;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Backend_Exam_Project.Repository.Auth;

public class AuthRepository(
    AppDbContext context
) : IAuthRepository
{
    #region LOGIN
    public async Task<LoginDTO?> Login(string Email)
    {
        var login = await context.User.FirstOrDefaultAsync(x => x.Email == Email);
        return login?.Adapt<LoginDTO>();
    }
    #endregion

    #region GET USER INFO USING EMAIL
    public async Task<UserInfoDTO?> UserInfo(string Email)
    {
        var user = await context.User.Include(u => u.Roles).Select(s => new { s.UserID, s.UserName, s.Roles.RoleName, s.Email}).FirstOrDefaultAsync(u => u.Email == Email);
        return user?.Adapt<UserInfoDTO>();
    }
    #endregion
}
