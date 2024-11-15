using AuthService.Model.Enum;

namespace AuthService.Model.UserModel.DTOs;

public class RegisterUserDto
{
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTime Birthday { get; set; }
    public string? PhoneNumber { get; set; }
    public required TipoDocumento TipoDocumento { get; set; }
    public required string Document { get; set; }
}