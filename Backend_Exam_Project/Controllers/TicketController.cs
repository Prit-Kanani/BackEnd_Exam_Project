using Backend_Exam_Project.DTOs;
using Backend_Exam_Project.Services.Ticket;
using Microsoft.AspNetCore.Mvc;

namespace Backend_Exam_Project.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TicketController(
    ITicketService ticketService
) : ControllerBase
{
    [HttpGet]
    [Produces<List<ListTicketsDTO>>]
    public async Task<IActionResult> SelectTickets(int skip, int take)
    {
        var response = await ticketService.SelectTickets(skip,take);
        return Ok(response);
    }

    [HttpPost]
    [Produces<OperationResultDTO>]
    public async Task<IActionResult> CreateTicket(CreateTicketDTO dto)
    {
        var response = await ticketService.CreateTicket(dto);
        return Ok(response);
    }
}
