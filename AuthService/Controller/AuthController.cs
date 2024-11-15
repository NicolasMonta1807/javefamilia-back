using AuthService.Model;
using AuthService.Service;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controller;

[ApiController]
[Route("/auth")]
public class AuthController : ControllerBase
{
    private readonly AuthControllerService _authService;

    public AuthController(AuthControllerService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var token = await _authService.LoginAsync(request.Email, request.Password);

        if (token is null) return Unauthorized();
        return Ok(new { Token = token });
    }
}