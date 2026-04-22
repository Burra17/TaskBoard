using MediatR;
using TaskBoard.Application.Interfaces;
using TaskBoard.Domain.Common;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Commands.Projects;

public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Result<Guid>>
{
    private readonly IRepository<Project> _repository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateProjectCommandHandler(IRepository<Project> repository, IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    // Creates a new project and returns its Id
    public async Task<Result<Guid>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
    {
        var project = new Project
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description
        };

        await _repository.AddAsync(project);
        await _unitOfWork.SaveChangesAsync();

        return Result<Guid>.Created(project.Id);
    }
}
