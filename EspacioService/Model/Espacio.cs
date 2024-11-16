using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EspacioService.Model
{
    public class Espacio
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; } 
        public string? Name { get; set; } 
        public string? Description { get; set; }
        public TimeSpan OpeningTime { get; set; }
        public TimeSpan ClosingTime { get; set; }
        public int Capacity { get; set; }
        public double AffiliateRate { get; set; }
        public double NonAffiliateRate { get; set; }
        public double BeneficiaryRate { get; set; }
        public List<HorarioEspacio> Horarios { get; set; } = new List<HorarioEspacio>();
    }
}