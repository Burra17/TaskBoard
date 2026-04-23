using AutoMapper;
using MediatR;
using TaskBoard.Application.Common.Pagination;
using TaskBoard.Application.DTOs;
using TaskBoard.Application.Interfaces;
using TaskBoard.Domain.Common;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Queries.Tickets;

public class GetAllTicketsQueryHandler : IRequestHandler<GetAllTicketsQuery, Result<PagedResult<TicketDto>>>
{
    private readonly IRepository<Ticket> _repository;
    private readonly IMapper _mapper;

    public GetAllTicketsQueryHandler(IRepository<Ticket> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Result<PagedResult<TicketDto>>> Handle(GetAllTicketsQuery request, CancellationToken cancellationToken)
    {
        var pagedResult = await _repository.GetPagedAsync(request.PaginationParams.PageNumber, request.PaginationParams.PageSize);

        var ticketDtos = _mapper.Map<IEnumerable<TicketDto>>(pagedResult.Items);

        var pagedResultDto = new PagedResult<TicketDto>
        (
            ticketDtos,
            pagedResult.TotalCount,
            request.PaginationParams.PageNumber,
            request.PaginationParams.PageSize
        );

        return Result<PagedResult<TicketDto>>.Ok(pagedResultDto);
    }
}
