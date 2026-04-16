using MediatR;

namespace TaskBoard.Application.Commands.Auth;

public record LoginCommand(string Username, string Password) : IRequest<string>;
