using Backend_Exam_Project.DTOs;
using Backend_Exam_Project.Exceptions;
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
        if (dto.RoleID == 0)
        {
            throw new NotFoundException($"Role '{dto.RoleName}' was not found.");
        }

        return await userRepository.CreateUser(dto);
    }

    public async Task<List<ListUsersDTO>> SelectUsers(int skip, int take)
    {
        return await userRepository.SelectUsers(skip, take);
    }
}
