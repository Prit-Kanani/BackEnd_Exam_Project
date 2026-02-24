using Backend_Exam_Project.Data;
using Backend_Exam_Project.DTOs;
using Backend_Exam_Project.Models;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Backend_Exam_Project.Repository.Ticket;

public class TicketRepository(
    AppDbContext contex
): ITicketRepository
{
    public async Task<OperationResultDTO> CreateTicket(CreateTicketDTO dto)
    {
        var tickets = dto.Adapt<Tickets>();
        await contex.Ticket.AddAsync(tickets);
        var rows = await contex.SaveChangesAsync();
        var response = new OperationResultDTO { Id = tickets.TicketID, RowsAffected = rows };
        return response;
    }

    public async Task<List<ListTicketsDTO>> SelectTickets(int skip, int take)
    {
        var tickets = await contex.Ticket.Skip(skip).Take(take).AsNoTracking().ToListAsync();
        var response = tickets.Adapt<List<ListTicketsDTO>>();
        return response;
    }
}
