using TaskBoard.Domain.Enums;

namespace TaskBoard.Application.DTOs;

public record TicketDto(
    Guid Id,
    string Title,
    string? Description,
    Priority Priority,
    Status Status,
    DateTime CreatedAt,
    DateTime? UpdatedAt,
    Guid ProjectId
    );