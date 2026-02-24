using Backend_Exam_Project.DTOs;

namespace Backend_Exam_Project.Repository.User;

public interface IUserRepository
{
    Task<OperationResultDTO> CreateUser(CreateUserDTO dto);
    Task<List<ListUsersDTO>> SelectUsers(int skip, int take);
}
