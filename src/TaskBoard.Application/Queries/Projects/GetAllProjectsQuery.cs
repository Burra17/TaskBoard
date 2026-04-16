using MediatR;
using TaskBoard.Application.DTOs;

namespace TaskBoard.Application.Queries.Projects;

public record GetAllProjectsQuery : IRequest<IEnumerable<ProjectDto>>;
