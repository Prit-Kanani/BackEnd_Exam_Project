using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_Exam_Project.Models;

[Table("Tickets")]
public class Tickets
{
    [Key]
    public int TicketID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Status { get; set; }
    public string Priority { get; set; }
    public int AssignedTo { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public int CreatedBy { get; set; }

    [ForeignKey(nameof(CreatedBy))]
    public Users CreatedByUser { get; set; }

    [ForeignKey(nameof(AssignedTo))]
    public Users AssignedUser { get; set; }
}
