using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SedesService.Model;

public class Sede
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string Name { get; set; }
    public string Address { get; set; }
    public string? PhoneNumber { get; set; }
    public string City { get; set; }
}