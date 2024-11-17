using Confluent.Kafka;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace EspacioService.Mensajeria{
public class QueueSender
{
    private readonly IProducer<string, string> _producer;

    public QueueSender(string bootstrapServers)
    {
        var producerConfig = new ProducerConfig { BootstrapServers = bootstrapServers };
        _producer = new ProducerBuilder<string, string>(producerConfig).Build();
    }

    public async Task SendEspacioEvent(EspacioEvent espacioEvent)
    {
        var message = new Message<string, string>
        {
            Key = espacioEvent.Id,
            Value = JsonConvert.SerializeObject(espacioEvent)
        };
        try
        {
            var result = await _producer.ProduceAsync("espacio-events", message);
            Console.WriteLine($"Mensaje enviado a Kafka: {result.TopicPartitionOffset}");
        }
        catch (ProduceException<string, string> ex)
        {
            Console.WriteLine($"Error enviando mensaje a Kafka: {ex.Error.Reason}");
        }
    }
    public async Task SendHorarioEvent(HorarioEvent horarioEvent)
    {
        var message = new Message<string, string>
        {
            Key = horarioEvent.Id,
            Value = JsonConvert.SerializeObject(horarioEvent)
        };
        try
        {
            var result = await _producer.ProduceAsync("horario-events", message);
            Console.WriteLine($"Mensaje enviado a Kafka: {result.TopicPartitionOffset}");
        }
        catch (ProduceException<string, string> ex)
        {
            Console.WriteLine($"Error enviando mensaje a Kafka: {ex.Error.Reason}");
        }
}
}
}