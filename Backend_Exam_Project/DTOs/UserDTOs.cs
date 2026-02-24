using Backend_Exam_Project.Models;
using System.ComponentModel;

namespace Backend_Exam_Project.DTOs;

public class CreateUserDTO
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string RoleName { get; set; }
    public int? RoleID { get; set; }
}

public class ListUsersDTO
{
    public int UserID { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public UserRole Role { get; set; } 
    public DateTime CreatedAt { get; set; }
}
public class UserRole
{
    public int RoleID { get; set; }
    public string RoleName { get; set; }
}
