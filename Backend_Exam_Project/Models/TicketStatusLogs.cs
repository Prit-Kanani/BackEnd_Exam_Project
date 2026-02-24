using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_Exam_Project.Models;

[Table("TicketStatusLogs")]
public class TicketStatusLogs
{
    [Key]
    public int TicketStatusLogID { get; set; }
    public int TicketID { get; set; }
    public string OldStatus { get; set; }
    public string NewStatus { get; set; }
    public int ChangedByID { get; set; }
    public DateTime ChangedAt { get; set; } = DateTime.Now;

    [ForeignKey(nameof(ChangedByID))]
    public Users Users { get; set; }
}
