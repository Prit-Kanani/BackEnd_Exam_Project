using Backend_Exam_Project.DTOs;
using Backend_Exam_Project.Exceptions;
using Backend_Exam_Project.Repository.Ticket;
using Backend_Exam_Project.Repository.User;

namespace Backend_Exam_Project.Services.Ticket;

public class TicketService(
    ITicketRepository ticketRepository,
    IUserRepository userRepository
) : ITicketService
{
    public async Task<OperationResultDTO> CreateTicket(CreateTicketDTO dto, int currentUserId)
    {
        var currentUserExists = await userRepository.UserExists(currentUserId);
        if (!currentUserExists)
        {
            throw new NotFoundException("Current user was not found.");
        }

        if (dto.AssignedTo.HasValue)
        {
            var assignedUserExists = await userRepository.UserExists(dto.AssignedTo.Value);
            if (!assignedUserExists)
            {
                throw new NotFoundException("Assigned user was not found.");
            }
        }

        return await ticketRepository.CreateTicket(dto, currentUserId);
    }

    public async Task<List<ListTicketsDTO>> SelectTickets(int skip, int take)
    {
        return await ticketRepository.SelectTickets(skip, take);
    }
}
