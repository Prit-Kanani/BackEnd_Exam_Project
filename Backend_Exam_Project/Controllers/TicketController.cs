using Backend_Exam_Project.DTOs;
using Backend_Exam_Project.Services.Ticket;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Backend_Exam_Project.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class TicketController(
    ITicketService ticketService,
    IValidator<CreateTicketDTO> createTicketValidator
) : ControllerBase
{
    [HttpGet]
    [Produces<List<ListTicketsDTO>>]
    public async Task<IActionResult> SelectTickets(int skip, int take)
    {
        var response = await ticketService.SelectTickets(skip, take);
        return Ok(response);
    }

    [HttpPost]
    [Produces<OperationResultDTO>]
    public async Task<IActionResult> CreateTicket(CreateTicketDTO dto)
    {
        createTicketValidator.ValidateAndThrow(dto);

        var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? User.FindFirstValue("sub");
        if (!int.TryParse(userIdClaim, out var currentUserId))
        {
            return Unauthorized();
        }

        var response = await ticketService.CreateTicket(dto, currentUserId);
        return Ok(response);
    }
}
