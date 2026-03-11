using Backend_Exam_Project.Models;
using System.ComponentModel;

namespace Backend_Exam_Project.DTOs;

public class CreateUserDTO
{
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string RoleName { get; set; } = string.Empty;
    public int? RoleID { get; set; }
}

public class ListUsersDTO
{
    public int UserID { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public UserRole Role { get; set; } = new();
    public DateTime CreatedAt { get; set; }
}
public class UserRole
{
    public int RoleID { get; set; }
    public string RoleName { get; set; } = string.Empty;
}
