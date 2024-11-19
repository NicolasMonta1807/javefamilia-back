using AuthService.Model.UserModel.DTOs;
using AuthService.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LoginRequest = AuthService.Model.LoginRequest;

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

    [HttpPost("register-na")]
    public async Task<IActionResult> RegisterNonAffiliate([FromBody] RegisterUserDto request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var success = await _authService.RegisterNonAffiliateUserAsync(request);
        if (!success) return BadRequest("User with this email already exists");

        return Ok(new { Success = success, Message = "User registered" });
    }

    [HttpPost("register")]
    [Authorize(Roles = "Administrador, Operario")]
    public async Task<IActionResult> Register([FromBody] RegisterUserDto request)
    {
        var success = await _authService.RegisterAffiliateUserAsync(request);

        if (!success) return BadRequest("User with this email already exists");

        return Ok(new { Success = success, Message = "User registered" });
    }
}