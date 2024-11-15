using AuthService.Model.Enum;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AuthService.Model.UserModel;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public required string Email { get; set; }
    public required string PasswordHash { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public DateTime Birthday { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime DateJoined { get; set; }
    public Role Role { get; set; }
    public required TipoDocumento TipoDocumento { get; set; }
    public required string Document { get; set; }
}