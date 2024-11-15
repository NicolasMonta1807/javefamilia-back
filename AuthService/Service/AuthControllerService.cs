using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthService.Model.Enum;
using AuthService.Model.UserModel;
using AuthService.Model.UserModel.DTOs;
using AuthService.Properties;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;

namespace AuthService.Service;

public class AuthControllerService
{
    private const string Issuer = "javefamilia.org";
    private readonly string? _secretKey;
    private readonly IMongoCollection<User> _users;

    public AuthControllerService(IOptions<UserDatabaseSettings> userDatabaseSettings, IConfiguration configuration)
    {
        _secretKey = configuration["JwtSettings:SecretKey"];

        var mongoClient = new MongoClient(
            userDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            userDatabaseSettings.Value.DatabaseName);

        _users = mongoDatabase.GetCollection<User>(
            userDatabaseSettings.Value.CollectionName);
    }

    public async Task<string?> LoginAsync(string email, string password)
    {
        var user = await _users.Find(u => u.Email == email).FirstOrDefaultAsync();

        if (user == null || !VerifyPassword(password, user.PasswordHash))
            return null;

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_secretKey);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, user.Role.ToString())
            }),
            Expires = DateTime.UtcNow.AddHours(24),
            SigningCredentials =
                new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = Issuer
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    public async Task<bool> RegisterNonAffiliateUserAsync(RegisterUserDto newUser)
    {
        var existingUser = await _users.Find(u => u.Email == newUser.Email).FirstOrDefaultAsync();
        if (existingUser != null)
            return false;

        var userToRegister = new User
        {
            Email = newUser.Email,
            Birthday = newUser.Birthday,
            DateJoined = DateTime.Now,
            TipoDocumento = newUser.TipoDocumento,
            Document = newUser.Document,
            FirstName = newUser.FirstName,
            LastName = newUser.LastName,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(newUser.Password),
            PhoneNumber = newUser.PhoneNumber,
            Role = Role.NoAfiliado
        };

        await _users.InsertOneAsync(userToRegister);
        return true;
    }

    private static bool VerifyPassword(string password, string passwordHash)
    {
        return BCrypt.Net.BCrypt.Verify(password, passwordHash);
    }
}