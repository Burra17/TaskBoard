using MediatR;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Queries.Tickets;

public record GetAllTicketsQuery : IRequest<IEnumerable<Ticket>>;
