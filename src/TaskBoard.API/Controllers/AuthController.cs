using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskBoard.Application.Commands.Auth;

namespace TaskBoard.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // POST api/auth/register
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    // POST api/auth/login
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginCommand command)
    {
        var token = await _mediator.Send(command);
        return Ok(new { token });
    }
}
