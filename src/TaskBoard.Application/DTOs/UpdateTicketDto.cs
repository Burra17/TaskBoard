using TaskBoard.Domain.Enums;

namespace TaskBoard.Application.DTOs;

public record UpdateTicketDto(string Title, string? Description, Priority Priority, Status Status);
