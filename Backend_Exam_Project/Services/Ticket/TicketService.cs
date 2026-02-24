using Backend_Exam_Project.DTOs;
using Backend_Exam_Project.Repository.Ticket;

namespace Backend_Exam_Project.Services.Ticket;

public class TicketService(
    ITicketRepository ticketRepository
) : ITicketService
{
    public async Task<OperationResultDTO> CreateTicket(CreateTicketDTO dto)
    {
        var response = await ticketRepository.CreateTicket(dto);
        return response;
    }

    public async  Task<List<ListTicketsDTO>> SelectTickets(int skip, int take)
    {
        var response = await ticketRepository.SelectTickets(skip, take);
        return response;
    }
}
