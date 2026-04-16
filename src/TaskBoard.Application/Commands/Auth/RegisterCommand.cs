using MediatR;

namespace TaskBoard.Application.Commands.Auth;

public record RegisterCommand(string UserName, string Password) : IRequest<Guid>;
