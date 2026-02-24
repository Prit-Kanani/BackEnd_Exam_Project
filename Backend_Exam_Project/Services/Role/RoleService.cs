using Backend_Exam_Project.DTOs;
using Backend_Exam_Project.Repository.Role;

namespace Backend_Exam_Project.Services.Role;

public class RoleService(
    IRoleRepository roleRepository
) : IRoleService
{
    public async Task<OperationResultDTO> CreateRole(string RoleName)
    {
        var response = await roleRepository.CreateRole(RoleName);
        return response;
    }

    public async Task<int> RoleIDByRoleName(string roleName)
    {
        var response = await roleRepository.RoleIDByRoleName(roleName);
        return response;
    }
}
