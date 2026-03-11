namespace Backend_Exam_Project.DTOs;

public class CreateRoleDTO
{
    public string RoleName { get; set; } = string.Empty;
}

public class ListRoleDTO
{
    public int RoleID { get; set; }
    public string RoleName { get; set; } = string.Empty;
}
