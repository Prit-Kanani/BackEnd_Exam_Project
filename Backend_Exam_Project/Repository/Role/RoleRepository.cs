using Backend_Exam_Project.Data;
using Backend_Exam_Project.DTOs;
using Backend_Exam_Project.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Backend_Exam_Project.Repository.Role;

public class RoleRepository(
    AppDbContext contex
) : IRoleRepository
{
    public async Task<OperationResultDTO> CreateRole(string RoleName)
    {
        var role = new Roles { RoleName = RoleName };
        await contex.Role.AddAsync(role);
        var rows = await contex.SaveChangesAsync();
        var response = new OperationResultDTO { Id = role.RoleID, RowsAffected = rows };
        return response;
    }

    public async Task<int> RoleIDByRoleName(string roleName)
    {
        var response = await contex.Role.Where(x => x.RoleName == roleName).Select(role => role.RoleID).FirstOrDefaultAsync();
        return response != null ? response : 0;
    }
}
