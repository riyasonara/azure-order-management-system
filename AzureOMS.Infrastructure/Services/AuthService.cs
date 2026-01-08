using AzureOMS.Application.Interfaces;
using AzureOMS.Domain.Entities;
using AzureOMS.Infrastructure.Auth;
using AzureOMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AzureOMS.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly AppDbContext _dbContext;
    private readonly JwtTokenGenerator _jwtTokenGenerator;

    public AuthService(AppDbContext context, JwtTokenGenerator jwtTokenGenerator)
    {
        _dbContext = context;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<string> LoginAsync(string email, string password)
    {
        var user = await _dbContext.Users.SingleOrDefaultAsync(x => x.Email == email);

        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
        {
            throw new Exception("Invalid credentials");
        }

        return _jwtTokenGenerator.GenerateToken(user.Id, user.Email);
    }

    public async Task<User> RegisterAsync(string email, string password)
    {
        var userExists = _dbContext.Users.Any(x => x.Email == email);

        if (userExists)
            throw new Exception("User already exists");

        var user = new User
        {
            Id = Guid.NewGuid(),
            Email = email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(password)
        };

        _dbContext.Users.Add(user);
        await _dbContext.SaveChangesAsync();

        return user;
    }
}
