using MediatR;

namespace TaskBoard.Application.Commands.Projects;

public record CreateProjectCommand(string Name, string? Description) : IRequest<Guid>;
