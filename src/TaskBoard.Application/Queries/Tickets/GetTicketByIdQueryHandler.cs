using AutoMapper;
using MediatR;
using TaskBoard.Application.DTOs;
using TaskBoard.Application.Interfaces;
using TaskBoard.Domain.Common;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Queries.Tickets;

public class GetTicketByIdQueryHandler : IRequestHandler<GetTicketByIdQuery, Result<TicketDto?>>
{
    private readonly IRepository<Ticket> _repository;
    private readonly IMapper _mapper;

    public GetTicketByIdQueryHandler(IRepository<Ticket> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<TicketDto?>> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
    {
        var ticketDto = _mapper.Map<TicketDto?>(await _repository.GetByIdAsync(request.Id));

        if (ticketDto == null)
            return Result<TicketDto?>.Fail($"Ticket with id: {request.Id} not found", 404);

        return Result<TicketDto?>.Ok(ticketDto);
    }
}
