using AutoMapper;
using MediatR;
using TaskBoard.Application.DTOs;
using TaskBoard.Application.Interfaces;
using TaskBoard.Domain.Common;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Queries.Tickets;

public class GetAllTicketsQueryHandler : IRequestHandler<GetAllTicketsQuery, Result<IEnumerable<TicketDto>>>
{
    private readonly IRepository<Ticket> _repository;
    private readonly IMapper _mapper;

    public GetAllTicketsQueryHandler(IRepository<Ticket> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<TicketDto>>> Handle(GetAllTicketsQuery request, CancellationToken cancellationToken)
    {
        var ticketDtos = _mapper.Map<IEnumerable<TicketDto>>(await _repository.GetAllAsync());

        return Result<IEnumerable<TicketDto>>.Ok(ticketDtos);
    }
}
