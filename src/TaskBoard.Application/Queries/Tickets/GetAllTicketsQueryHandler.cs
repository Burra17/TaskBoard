using AutoMapper;
using MediatR;
using TaskBoard.Application.DTOs;
using TaskBoard.Application.Interfaces;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Queries.Tickets;

public class GetAllTicketsQueryHandler : IRequestHandler<GetAllTicketsQuery, IEnumerable<TicketDto>>
{
    private readonly IRepository<Ticket> _repository;
    private readonly IMapper _mapper;

    public GetAllTicketsQueryHandler(IRepository<Ticket> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TicketDto>> Handle(GetAllTicketsQuery request, CancellationToken cancellationToken)
    {
        // Fetch all tickets and map to DTOs
        return _mapper.Map<IEnumerable<TicketDto>>(await _repository.GetAllAsync());
    }
}
