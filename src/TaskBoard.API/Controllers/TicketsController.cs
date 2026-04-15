using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskBoard.Application.Commands.Tickets;

namespace TaskBoard.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TicketsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // POST api/tickets
    [HttpPost]
    public async Task<IActionResult> CreateTicket(CreateTicketCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(CreateTicket), new { id = result }, result);
    }
}
