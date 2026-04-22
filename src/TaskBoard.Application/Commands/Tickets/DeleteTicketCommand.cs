using MediatR;
using TaskBoard.Domain.Common;

namespace TaskBoard.Application.Commands.Tickets;

public record DeleteTicketCommand(Guid Id) : IRequest<Result<Unit>>;
