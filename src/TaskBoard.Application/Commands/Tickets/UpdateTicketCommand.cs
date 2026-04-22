using MediatR;
using TaskBoard.Application.DTOs;
using TaskBoard.Domain.Common;
using TaskBoard.Domain.Enums;

namespace TaskBoard.Application.Commands.Tickets;

public record UpdateTicketCommand(Guid Id, string Title, string? Description, Priority Priority, Status Status) : IRequest<Result<TicketDto>>;
