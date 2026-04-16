using MediatR;
using TaskBoard.Application.Interfaces;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Commands.Tickets;

public class DeleteTicketCommandHandler : IRequestHandler<DeleteTicketCommand, Unit>
{
    private readonly IRepository<Ticket> _repository;

    public DeleteTicketCommandHandler(IRepository<Ticket> repository)
    {
        _repository = repository;
    }

    public async Task<Unit> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = await _repository.GetByIdAsync(request.Id);

        if (ticket == null)
            throw new KeyNotFoundException($"Ticket with id {request.Id} not found");

        _repository.Delete(ticket);
        await _repository.SaveChangesAsync();

        return Unit.Value;
    }
}
