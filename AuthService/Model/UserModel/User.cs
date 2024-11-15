using AuthService.Model.Enum;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AuthService.Model;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime Birthday { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime DateJoined { get; set; }
    public Role Role { get; set; }
    public TipoDocumento? TipoDocumento { get; set; }
    public string? Document { get; set; }
}