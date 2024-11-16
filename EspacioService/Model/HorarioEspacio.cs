using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EspacioService.Model;

public class HorarioEspacio
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public bool Availavility { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
}