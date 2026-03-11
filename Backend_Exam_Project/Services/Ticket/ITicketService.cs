using Backend_Exam_Project.DTOs;

namespace Backend_Exam_Project.Services.Ticket;

public interface ITicketService
{
    Task<OperationResultDTO> CreateTicket(CreateTicketDTO dto, int currentUserId);
    Task<List<ListTicketsDTO>> SelectTickets(int skip, int take);
}
