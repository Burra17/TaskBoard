using MediatR;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Queries.Tickets;

public record GetTicketByIdQuery(Guid Id) : IRequest<Ticket?>;
