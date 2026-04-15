using MediatR;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Queries.Projects;

public record GetAllProjectsQuery : IRequest<IEnumerable<Project>>;
