using Backend_Exam_Project.DTOs;
using Backend_Exam_Project.Repository.Role;

namespace Backend_Exam_Project.Services.Role;

public class RoleService(
    IRoleRepository roleRepository
) : IRoleService
{
    public async Task<OperationResultDTO> CreateRole(string RoleName)
    {
        return await roleRepository.CreateRole(RoleName);
    }

    public async Task<int> RoleIDByRoleName(string roleName)
    {
        return await roleRepository.RoleIDByRoleName(roleName);
    }

    public async Task<List<ListRoleDTO>> SelectRoles()
    {
        return await roleRepository.SelectRoles();
    }
}
