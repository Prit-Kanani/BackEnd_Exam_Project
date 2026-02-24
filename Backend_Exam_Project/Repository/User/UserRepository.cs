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
        var response = new OperationResultDTO { Id = user.UserID, RowsAffected = rows };
        return response;
    }
    public async Task<List<ListUsersDTO>> SelectUsers(int skip, int take)
    {
       var users = await contex.User.Include(r => r.Roles)
            .Skip(skip)
            .Take(take)
            .ToListAsync();

        // Map each Users -> ListUsersDTO along with the nested Role object
        var response = users.Select(u => new ListUsersDTO
        {
            UserID = u.UserID,
            UserName = u.UserName,
            Email = u.Email,
            CreatedAt = u.CreatedAt,
            Role = new UserRole
            {
                RoleID = u.Roles.RoleID,
                RoleName = u.Roles.RoleName.ToString()
            }
        }).ToList();

        return response;
    }
}
