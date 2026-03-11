using Backend_Exam_Project.DTOs;

namespace Backend_Exam_Project.Repository.Ticket;

public interface ITicketRepository
{
    Task<OperationResultDTO> CreateTicket(CreateTicketDTO dto, int currentUserId);
    Task<List<ListTicketsDTO>> SelectTickets(int skip, int take);
}
