using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_Exam_Project.Models;

[Table("Roles")]
[Index(nameof(RoleName), IsUnique = true)]
public class Roles
{
    [Key]
    public int RoleID { get; set; }
    [Required]
    [MaxLength(20)]
    public string RoleName { get; set; }
}
