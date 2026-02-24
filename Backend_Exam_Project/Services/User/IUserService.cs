using Backend_Exam_Project.DTOs;

namespace Backend_Exam_Project.Services.User;

public interface IUserService
{
    Task<OperationResultDTO> CreateUser(CreateUserDTO dto);
    Task<List<ListUsersDTO>> SelectUsers(int skip, int take);
}
