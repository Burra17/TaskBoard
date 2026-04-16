using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskBoard.Application.Interfaces;
using TaskBoard.Domain.Models;

namespace TaskBoard.Application.Commands.Auth;

public class LoginCommandHandler : IRequestHandler<LoginCommand, string>
{
    private readonly IRepository<User> _repository;
    private readonly IConfiguration _configuration;

    public LoginCommandHandler(IRepository<User> repository, IConfiguration configuration)
    {
        _repository = repository;
        _configuration = configuration;
    }

    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        // Find user by username
        var users = await _repository.GetAllAsync();
        var user = users.FirstOrDefault(u => u.UserName == request.Username);

        // Verify password
        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            throw new UnauthorizedAccessException("Invalid username or password.");

        // Create JWT claims
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };

        // Generate and return JWT token
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddHours(1),
            signingCredentials: credentials
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
