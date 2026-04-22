using MediatR;
using TaskBoard.Domain.Common;

namespace TaskBoard.Application.Commands.Auth;

public record RegisterCommand(string UserName, string Password) : IRequest<Result<Guid>>;
