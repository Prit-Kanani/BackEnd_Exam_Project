using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend_Exam_Project.Models;

[Table("TicketComments")]
public class TicketComments
{
    [Key]
    public int TicketCommentID { get; set; }
    public int TicktID { get; set; }
    public int CommentedByID { get; set; }
    public string Comment { get; set; }
    public DateTime CreatedAt { get; set; }

    [ForeignKey(nameof(CommentedByID))]
    public Users Users { get; set; }

    [ForeignKey(nameof(TicktID))]
    public Tickets Tickets { get; set; }
}
