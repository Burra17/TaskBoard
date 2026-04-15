using MediatR;
using TaskBoard.Application.Interfaces;
using TaskBoard.Domain.Enums;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Commands.Tickets;

public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, Guid>
{
    private readonly IRepository<Ticket> _repository;

    public CreateTicketCommandHandler(IRepository<Ticket> repository)
    {
        _repository = repository;
    }

    // Creates a new Ticket and returns its Id
    public async Task<Guid> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = new Ticket
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            Priority = request.Priority,
            Status = Status.ToDo,
            ProjectId = request.ProjectId,
        };

        await _repository.AddAsync(ticket);
        await _repository.SaveChangesAsync();

        return ticket.Id;
    }
}
