namespace Backend_Exam_Project.DTOs;

public class CreateTicketDTO
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Priority { get; set; }
}

public class ListTicketsDTO
{
    public int TicketID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Priority { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public ListUsersDTO CreatedBy { get; set; }
    public ListUsersDTO AssignTo { get; set; }
}
