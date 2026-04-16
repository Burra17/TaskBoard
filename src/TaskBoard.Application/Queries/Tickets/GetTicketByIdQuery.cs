using MediatR;
using TaskBoard.Application.DTOs;

namespace TaskBoard.Application.Queries.Tickets;

public record GetTicketByIdQuery(Guid Id) : IRequest<TicketDto?>;
