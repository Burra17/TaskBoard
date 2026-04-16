using MediatR;
using TaskBoard.Application.Interfaces;
using TaskBoard.Domain.Enums;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Commands.Auth;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Guid>
{
    private readonly IRepository<User> _repository;

    public RegisterCommandHandler(IRepository<User> repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            UserName = request.UserName,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            Role = Role.Member
        };

        await _repository.AddAsync(user);
        await _repository.SaveChangesAsync();
        
        return user.Id;
    }
}
