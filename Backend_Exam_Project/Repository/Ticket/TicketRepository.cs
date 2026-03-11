using Backend_Exam_Project.Data;
using Backend_Exam_Project.DTOs;
using Backend_Exam_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend_Exam_Project.Repository.Ticket;

public class TicketRepository(
    AppDbContext contex
) : ITicketRepository
{
    public async Task<OperationResultDTO> CreateTicket(CreateTicketDTO dto, int currentUserId)
    {
        var tickets = new Tickets
        {
            Title = dto.Title,
            Description = dto.Description,
            Priority = dto.Priority,
            Status = "Open",
            CreatedBy = currentUserId,
            AssignedTo = dto.AssignedTo ?? currentUserId
        };

        await contex.Ticket.AddAsync(tickets);
        var rows = await contex.SaveChangesAsync();
        return new OperationResultDTO { Id = tickets.TicketID, RowsAffected = rows };
    }

    public async Task<List<ListTicketsDTO>> SelectTickets(int skip, int take)
    {
        return await contex.Ticket
            .AsNoTracking()
            .Include(ticket => ticket.CreatedByUser)
                .ThenInclude(user => user.Roles)
            .Include(ticket => ticket.AssignedUser)
                .ThenInclude(user => user.Roles)
            .OrderByDescending(ticket => ticket.CreatedAt)
            .Skip(skip)
            .Take(take)
            .Select(ticket => new ListTicketsDTO
            {
                TicketID = ticket.TicketID,
                Title = ticket.Title,
                Description = ticket.Description,
                Priority = ticket.Priority,
                Status = ticket.Status,
                CreatedAt = ticket.CreatedAt,
                CreatedBy = new ListUsersDTO
                {
                    UserID = ticket.CreatedByUser.UserID,
                    UserName = ticket.CreatedByUser.UserName,
                    Email = ticket.CreatedByUser.Email,
                    CreatedAt = ticket.CreatedByUser.CreatedAt,
                    Role = new UserRole
                    {
                        RoleID = ticket.CreatedByUser.Roles.RoleID,
                        RoleName = ticket.CreatedByUser.Roles.RoleName
                    }
                },
                AssignTo = new ListUsersDTO
                {
                    UserID = ticket.AssignedUser.UserID,
                    UserName = ticket.AssignedUser.UserName,
                    Email = ticket.AssignedUser.Email,
                    CreatedAt = ticket.AssignedUser.CreatedAt,
                    Role = new UserRole
                    {
                        RoleID = ticket.AssignedUser.Roles.RoleID,
                        RoleName = ticket.AssignedUser.Roles.RoleName
                    }
                }
            })
            .ToListAsync();
    }
}
