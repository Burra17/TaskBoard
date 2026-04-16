using MediatR;
using TaskBoard.Application.Interfaces;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Queries.Tickets;

public class GetTicketByIdQueryHandler : IRequestHandler<GetTicketByIdQuery, Ticket?>
{
    private readonly IRepository<Ticket> _repository;

    public GetTicketByIdQueryHandler(IRepository<Ticket> repository)
    {
        _repository = repository;
    }

    public async Task<Ticket?> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id);
    }
}
