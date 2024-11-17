using Newtonsoft.Json;

namespace EspacioService.Mensajeria;

public class HorarioEvent
{
    public HorarioEvent(EspacioEventType eventType, string id, string EspacioId, bool availavility, TimeSpan startTime,
        TimeSpan endTime)
    {
        EventType = eventType;
        Id = id;
        EspacioId = this.EspacioId;
        Availavility = availavility;
        StartTime = startTime;
        EndTime = endTime;
    }

    public HorarioEvent(EspacioEventType eventType, string id)
    {
        EventType = eventType;
        Id = id;
    }

    public HorarioEvent(EspacioEventType eventType, string id, string EspacioId)
    {
        EventType = eventType;
        Id = id;
        EspacioId = this.EspacioId;
    }

    [JsonProperty("eventType")] public EspacioEventType EventType { get; set; }

    [JsonProperty("Id")] public string? Id { get; set; }

    [JsonProperty("Id")] public string? EspacioId { get; set; }

    [JsonProperty("Availavility")] public bool Availavility { get; set; }

    [JsonProperty("StartTime")] public TimeSpan StartTime { get; set; }

    [JsonProperty("EndTime")] public TimeSpan EndTime { get; set; }
}