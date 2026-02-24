using Backend_Exam_Project.DTOs;
using Backend_Exam_Project.Repository.Role;
using Backend_Exam_Project.Repository.User;
using Comman.Functions;

namespace Backend_Exam_Project.Services.User;

public class UserService(
    IUserRepository userRepository,
    IRoleRepository roleRepository
) : IUserService
{
    public async Task<OperationResultDTO> CreateUser(CreateUserDTO dto)
    {
        dto.Password = HashPass.HashPassword(dto.Password);
        dto.RoleID ??= await roleRepository.RoleIDByRoleName(dto.RoleName);
        var response = await userRepository.CreateUser(dto);
        return response;
    }
    public async Task<List<ListUsersDTO>> SelectUsers(int skip, int take)
    {
        var response = await userRepository.SelectUsers(skip, take);
        return response;    
    }
}
