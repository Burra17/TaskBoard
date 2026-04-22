using MediatR;
using TaskBoard.Domain.Common;
using TaskBoard.Domain.Enums;

namespace TaskBoard.Application.Commands.Tickets;

public record CreateTicketCommand(string Title, string? Description, Priority Priority, Guid ProjectId) : IRequest<Result<Guid>>;
