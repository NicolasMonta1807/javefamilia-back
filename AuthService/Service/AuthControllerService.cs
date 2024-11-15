using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthService.Model;
using AuthService.Model.Enum;
using AuthService.Properties;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;

namespace AuthService.Service;

public class AuthControllerService
{
    private const string Issuer = "javefamilia.org";
    private const string Audience = "YourAudience";
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
            Issuer = Issuer,
            Audience = Audience
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    private static bool VerifyPassword(string password, string passwordHash)
    {
        return string.Compare(password, passwordHash, StringComparison.Ordinal) == 0;
    }
}