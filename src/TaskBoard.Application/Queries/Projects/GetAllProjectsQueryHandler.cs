using AutoMapper;
using MediatR;
using TaskBoard.Application.DTOs;
using TaskBoard.Application.Interfaces;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Queries.Projects;

public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, IEnumerable<ProjectDto>>
{
    private readonly IRepository<Project> _repository;
    private readonly IMapper _mapper;

    public GetAllProjectsQueryHandler(IRepository<Project> repository, IMapper mapper)
    {
         _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProjectDto>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
    {
        // Fetch all tickets and map to DTOs
        return _mapper.Map<IEnumerable<ProjectDto>>(await _repository.GetAllAsync());
    }
}