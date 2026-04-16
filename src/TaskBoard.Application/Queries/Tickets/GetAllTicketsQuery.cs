using MediatR;
using TaskBoard.Application.DTOs;

namespace TaskBoard.Application.Queries.Tickets;

public record GetAllTicketsQuery : IRequest<IEnumerable<TicketDto>>;
