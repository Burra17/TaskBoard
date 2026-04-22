using MediatR;
using TaskBoard.Domain.Common;

namespace TaskBoard.Application.Commands.Projects;

public record CreateProjectCommand(string Name, string? Description) : IRequest<Result<Guid>>;
