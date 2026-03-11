using Backend_Exam_Project.Data;
using Backend_Exam_Project.DTOs;
using Backend_Exam_Project.Exceptions;
using Backend_Exam_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend_Exam_Project.Repository.Role;

public class RoleRepository(
    AppDbContext contex
) : IRoleRepository
{
    public async Task<OperationResultDTO> CreateRole(string RoleName)
    {
        var exists = await contex.Role.AnyAsync(x => x.RoleName == RoleName);
        if (exists)
        {
            throw new InvalidOperationException($"Role '{RoleName}' already exists.");
        }

        var role = new Roles { RoleName = RoleName };
        await contex.Role.AddAsync(role);
        var rows = await contex.SaveChangesAsync();
        return new OperationResultDTO { Id = role.RoleID, RowsAffected = rows };
    }

    public async Task<int> RoleIDByRoleName(string roleName)
    {
        var response = await contex.Role
            .Where(x => x.RoleName == roleName)
            .Select(role => role.RoleID)
            .FirstOrDefaultAsync();

        if (response == 0)
        {
            throw new NotFoundException($"Role '{roleName}' was not found.");
        }

        return response;
    }

    public async Task<List<ListRoleDTO>> SelectRoles()
    {
        return await contex.Role
            .AsNoTracking()
            .OrderBy(role => role.RoleName)
            .Select(role => new ListRoleDTO
            {
                RoleID = role.RoleID,
                RoleName = role.RoleName
            })
            .ToListAsync();
    }
}
