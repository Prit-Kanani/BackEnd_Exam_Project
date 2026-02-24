using Backend_Exam_Project.DTOs;

namespace Backend_Exam_Project.Services.Role;

public interface IRoleService
{
    Task<OperationResultDTO> CreateRole(string RoleName);
    Task<int> RoleIDByRoleName(string roleName);
}
