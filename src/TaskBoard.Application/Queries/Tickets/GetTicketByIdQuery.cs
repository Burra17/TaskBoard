using MediatR;
using TaskBoard.Application.DTOs;
using TaskBoard.Domain.Common;

namespace TaskBoard.Application.Queries.Tickets;

public record GetTicketByIdQuery(Guid Id) : IRequest<Result<TicketDto?>>;
