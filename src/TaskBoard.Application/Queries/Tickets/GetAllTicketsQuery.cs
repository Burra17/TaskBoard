using MediatR;
using TaskBoard.Application.DTOs;
using TaskBoard.Domain.Common;

namespace TaskBoard.Application.Queries.Tickets;

public record GetAllTicketsQuery : IRequest<Result<IEnumerable<TicketDto>>>;
