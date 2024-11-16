using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EspacioService.Model
{
    public class Espacio
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } 
        public string Name { get; set; } 
        public string Description { get; set; }
        public TimeSpan OpeningTime { get; set; }
        public TimeSpan ClosingTime { get; set; }
        public int capacidad { get; set; }
        public List<HorarioEspacio> Horarios { get; set; } = new List<HorarioEspacio>();
    }
}