using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Backend_Exam_Project.Models;

[Table("Users")]
[Index(nameof(Email), IsUnique = true)]
public class Users
{
    [Key]
    public int UserID { get; set; }
    public string UserName { get; set; }
    [Required]
    [MaxLength(256)]
    public string Email { get; set; }
    public string Password { get; set; }
    public int RoleID { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    [ForeignKey(nameof(RoleID))]
    public Roles Roles { get; set; }
}
