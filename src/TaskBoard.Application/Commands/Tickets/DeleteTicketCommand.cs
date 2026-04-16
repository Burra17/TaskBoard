using MediatR;

namespace TaskBoard.Application.Commands.Tickets;

public record DeleteTicketCommand(Guid Id) : IRequest<Unit>;
