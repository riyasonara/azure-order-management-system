using AzureOMS.Application.DTOs.Auth;
using AzureOMS.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AzureOms.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }


    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var user = await _authService.RegisterAsync(request.Email, request.Password);
        return Ok(user.Email);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var token = await _authService.LoginAsync(request.Email, request.Password);
        return Ok(new { token });
    }
}
