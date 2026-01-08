using AzureOMS.Application.Interfaces;
using AzureOMS.Domain.Entities;
using AzureOMS.Infrastructure.Auth;

namespace AzureOMS.Infrastructure.Services;

public class AuthService : IAuthService
{
    private static readonly List<User> Users = [];
    private readonly JwtTokenGenerator _jwtTokenGenerator;

    public AuthService(JwtTokenGenerator jwtTokenGenerator)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public Task<string> LoginAsync(string email, string password)
    {
        var user = Users.SingleOrDefault(x => x.Email == email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
        {
            throw new Exception("Invalid credentials");
        }

        var token = _jwtTokenGenerator.GenerateToken(user.Id, user.Email);
        return Task.FromResult(token);
    }

    public Task<User> RegisterAsync(string email, string password)
    {
        if (Users.Any(x => x.Email == email))
            throw new Exception("User already exists");

        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password)
        };

        Users.Add(user);
        return Task.FromResult(user);
    }
}
