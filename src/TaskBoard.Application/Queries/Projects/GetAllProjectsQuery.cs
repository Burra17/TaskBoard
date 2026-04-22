using MediatR;
using TaskBoard.Application.DTOs;
using TaskBoard.Domain.Common;

namespace TaskBoard.Application.Queries.Projects;

public record GetAllProjectsQuery : IRequest<Result<IEnumerable<ProjectDto>>>;
