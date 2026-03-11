using Backend_Exam_Project.Data;
using Backend_Exam_Project.DTOs;
using Backend_Exam_Project.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Backend_Exam_Project.Repository.User;

public class UserRepository(
    AppDbContext contex
) : IUserRepository
{
    public async Task<OperationResultDTO> CreateUser(CreateUserDTO dto)
    {
        var user = dto.Adapt<Users>();
        await contex.User.AddAsync(user);
        var rows = await contex.SaveChangesAsync();
        return new OperationResultDTO { Id = user.UserID, RowsAffected = rows };
    }

    public async Task<List<ListUsersDTO>> SelectUsers(int skip, int take)
    {
        var users = await contex.User.Include(r => r.Roles)
            .Skip(skip)
            .Take(take)
            .ToListAsync();

        return users.Select(u => new ListUsersDTO
        {
            UserID = u.UserID,
            UserName = u.UserName,
            Email = u.Email,
            CreatedAt = u.CreatedAt,
            Role = new UserRole
            {
                RoleID = u.Roles.RoleID,
                RoleName = u.Roles.RoleName
            }
        }).ToList();
    }

    public async Task<bool> UserExists(int userId)
    {
        return await contex.User.AnyAsync(user => user.UserID == userId);
    }
}
