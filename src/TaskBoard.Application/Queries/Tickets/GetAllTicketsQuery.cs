using MediatR;
using TaskBoard.Application.Common.Pagination;
using TaskBoard.Application.DTOs;
using TaskBoard.Domain.Common;

namespace TaskBoard.Application.Queries.Tickets;

public record GetAllTicketsQuery(PaginationParams PaginationParams) : IRequest<Result<PagedResult<TicketDto>>>;
