using MediatR;
using TaskBoard.Application.Interfaces;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Queries.Projects;

public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, IEnumerable<Project>>
{
    private readonly IRepository<Project> _repository;

    public GetAllProjectsQueryHandler(IRepository<Project> repository)
    {
         _repository = repository;
    }

    public async Task<IEnumerable<Project>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}