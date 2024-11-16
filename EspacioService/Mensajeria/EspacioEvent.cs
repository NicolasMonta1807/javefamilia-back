using Newtonsoft.Json;
using EspacioService.Model;

namespace EspacioService.Mensajeria;
public class EspacioEvent
{
    [JsonProperty("eventType")]
    public EspacioEventType EventType { get; set; }

    [JsonProperty("Id")]
    public string? Id { get; set; } 

    [JsonProperty("Name")]
    public string? Name { get; set; }

    [JsonProperty("Description")]
    public string? Description { get; set; }
    [JsonProperty("OpeningTime")]
    public TimeSpan OpeningTime { get; set; }
    [JsonProperty("ClosingTime")]
    public TimeSpan ClosingTime { get; set; }
    [JsonProperty("Capacity")]
    public int Capacity { get; set; }
    [JsonProperty("AffiliateRate")]
    public double AffiliateRate { get; set; }
    [JsonProperty("NonAffiliateRate")]
    public double NonAffiliateRate { get; set; }
    [JsonProperty("BeneficiaryRate")]
    public double BeneficiaryRate { get; set; }
    [JsonProperty("Horarios")]
    public List<HorarioEspacio> Horarios { get; set; } = new List<HorarioEspacio>();

    public EspacioEvent(EspacioEventType eventType, string id, string name, string description,
     TimeSpan openingTime, TimeSpan closingTime, int capacity, double affiliateRate,
      double nonAffiliateRate, double beneficiaryRate, List<HorarioEspacio> horarios)
    {
        EventType = eventType;
        Id = id;
        Name = name;
        Description = description;
        OpeningTime = openingTime;
        ClosingTime = closingTime;
        Capacity = capacity;
        AffiliateRate = affiliateRate;
        NonAffiliateRate = nonAffiliateRate;
        BeneficiaryRate = beneficiaryRate;
        Horarios = horarios;
    }
    public EspacioEvent(EspacioEventType eventType, string id)
    {
        EventType = eventType;
        Id = id;
    }
}