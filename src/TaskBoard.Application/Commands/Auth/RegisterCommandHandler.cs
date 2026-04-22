using MediatR;
using TaskBoard.Application.Interfaces;
using TaskBoard.Domain.Common;
using TaskBoard.Domain.Enums;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Commands.Auth;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<Guid>>
{
    private readonly IRepository<User> _repository;

    public RegisterCommandHandler(IRepository<User> repository)
    {
        _repository = repository;
    }

    public async Task<Result<Guid>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var users = await _repository.GetAllAsync();
        if (users.Any(u => u.UserName == request.UserName))
            return Result<Guid>.Fail("Username already exists", 400);

        var user = new User
        {
            Id = Guid.NewGuid(),
            UserName = request.UserName,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            Role = Role.Member
        };

        await _repository.AddAsync(user);
        await _repository.SaveChangesAsync();
        
        return Result<Guid>.Created(user.Id);
    }
}
