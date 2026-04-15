using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskBoard.Application.Commands.Projects;

namespace TaskBoard.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST api/projects
        [HttpPost]
        public async Task<IActionResult> CreateProject(CreateProjectCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(CreateProject), new { id = result }, result);
        }

    }
}
