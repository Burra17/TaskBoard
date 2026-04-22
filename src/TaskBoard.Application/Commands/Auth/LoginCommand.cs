using MediatR;
using TaskBoard.Domain.Common;

namespace TaskBoard.Application.Commands.Auth;

public record LoginCommand(string Username, string Password) : IRequest<Result<string>>;
