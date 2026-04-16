using MediatR;
using TaskBoard.Application.Interfaces;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Queries.Tickets;

public class GetAllTicketsQueryHandler : IRequestHandler<GetAllTicketsQuery, IEnumerable<Ticket>>
{
    private readonly IRepository<Ticket> _repository;

    public GetAllTicketsQueryHandler(IRepository<Ticket> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Ticket>> Handle(GetAllTicketsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}
