using MediatR;
using TaskBoard.Domain.Enums;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Commands.Tickets;

public record UpdateTicketCommand(Guid Id, string Title, string? Description, Priority Priority, Status Status) : IRequest<Ticket>;
