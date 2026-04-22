using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskBoard.Application.Commands.Projects;
using TaskBoard.Application.Queries.Projects;

namespace TaskBoard.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ApiController
{
    private readonly IMediator _mediator;

    public ProjectsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // POST api/projects
    [HttpPost]
    [Authorize (Roles = "Admin")]
    public async Task<IActionResult> CreateProject(CreateProjectCommand command)
    {
        var result = await _mediator.Send(command);
        return HandleResult(result);
    }

    // GET api/projects
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllProjects()
    {
        var result = await _mediator.Send(new GetAllProjectsQuery());
        return HandleResult(result);
    }
}
