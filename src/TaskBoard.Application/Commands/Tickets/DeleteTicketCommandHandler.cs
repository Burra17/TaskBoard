using MediatR;
using TaskBoard.Application.Interfaces;
using TaskBoard.Domain.Common;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Commands.Tickets;

public class DeleteTicketCommandHandler : IRequestHandler<DeleteTicketCommand, Result<Unit>>
{
    private readonly IRepository<Ticket> _repository;

    public DeleteTicketCommandHandler(IRepository<Ticket> repository)
    {
        _repository = repository;
    }

    public async Task<Result<Unit>> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
    {
        var ticket = await _repository.GetByIdAsync(request.Id);

        if (ticket == null)
            return Result<Unit>.Fail($"Ticket with id {request.Id} not found", 404);

        _repository.Delete(ticket);
        await _repository.SaveChangesAsync();

        return Result<Unit>.NoContent();
    }
}
