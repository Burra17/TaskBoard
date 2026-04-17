using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskBoard.Application.Commands.Tickets;
using TaskBoard.Application.DTOs;
using TaskBoard.Application.Queries.Tickets;

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
    [Authorize]
    public async Task<IActionResult> CreateTicket(CreateTicketCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(GetTicketById), new { id = result }, result);
    }

    // GET api/tickets
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllTickets()
    {
        var result = await _mediator.Send(new GetAllTicketsQuery());
        return Ok(result);
    }

    // GET api/ticket/{id}
    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetTicketById(Guid id)
    {
        var result = await _mediator.Send(new GetTicketByIdQuery(id));

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    // PUT api/ticket/{id}
    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> UpdateTicket(Guid id, UpdateTicketDto dto)
    {
        // Combine URL id with request body into a command
        var command = new UpdateTicketCommand(id, dto.Title, dto.Description, dto.Priority, dto.Status);
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    // DELETE api/ticket/{id}
    [HttpDelete("{id}")]
    [Authorize (Roles = "Admin")]
    public async Task<IActionResult> DeleteTicket(Guid id)
    {
        await _mediator.Send(new DeleteTicketCommand(id));
        return NoContent();
    }
}
