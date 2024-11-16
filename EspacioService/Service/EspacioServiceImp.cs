using EspacioService.Model;
using EspacioService.Properties;
using EspacioService.Mensajeria;
using System.Text;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace EspacioService.Service
{
    public class EspacioServiceImp
    {
        private readonly IMongoCollection<Espacio> _espacios;
        private QueueSender kafkaProducer = new QueueSender("localhost:9092");
        public EspacioServiceImp(IOptions<EspacioDatabaseSettings> espacioDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                espacioDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                espacioDatabaseSettings.Value.DatabaseName);

            _espacios = mongoDatabase.GetCollection<Espacio>(
                espacioDatabaseSettings.Value.CollectionName);
        }

        public async Task<List<Espacio>> GetEspaciosAsync()
        {
            return await _espacios.Find(espacio => true).ToListAsync();
        }

        public async Task<Espacio> GetEspacioByIdAsync(string id)
        {
            return await _espacios.Find(espacio => espacio.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateEspacioAsync(Espacio espacio)
        {
            for(int i=0; i<espacio.Horarios.Count; i++)
            {
                espacio.Horarios[i].Id = ObjectId.GenerateNewId().ToString();
            }
            await _espacios.InsertOneAsync(espacio);
            //Envío de evento a Kafka
            await kafkaProducer.SendEspacioEvent(new EspacioEvent(
                eventType: EspacioEventType.ESPACIO_CREATED,
                id: espacio.Id,
                name: espacio.Name,
                description: espacio.Description,
                openingTime: espacio.OpeningTime,
                closingTime: espacio.ClosingTime,
                capacity: espacio.Capacity,
                affiliateRate: espacio.AffiliateRate,
                nonAffiliateRate: espacio.NonAffiliateRate,
                beneficiaryRate: espacio.BeneficiaryRate,
                horarios: espacio.Horarios
            ));
        }
        public async Task AddHorarioAsync(string id, HorarioEspacio horario)
        {
            horario.Id = ObjectId.GenerateNewId().ToString();
            var filter = Builders<Espacio>.Filter.Eq(e => e.Id, id);
            var update = Builders<Espacio>.Update.Push(e => e.Horarios, horario);
            await _espacios.UpdateOneAsync(filter, update);
            //Envío de evento a Kafka
            await kafkaProducer.SendHorarioEvent(new HorarioEvent(
                eventType: EspacioEventType.ESPACIO_HORARIO_ADDED,
                id: horario.Id,
                EspacioId: id ,
                availavility: horario.Availavility,
                startTime: horario.StartTime,
                endTime: horario.EndTime
            ));
        }

        public async Task UpdateEspacioAsync(string id, Espacio espacio)
        {
            await _espacios.ReplaceOneAsync(e => e.Id == id, espacio);
            //Envío de evento a Kafka
            await kafkaProducer.SendEspacioEvent(new EspacioEvent(
                eventType: EspacioEventType.ESPACIO_UPDATED,
                id: espacio.Id,
                name: espacio.Name,
                description: espacio.Description,
                openingTime: espacio.OpeningTime,
                closingTime: espacio.ClosingTime,
                capacity: espacio.Capacity,
                affiliateRate: espacio.AffiliateRate,
                nonAffiliateRate: espacio.NonAffiliateRate,
                beneficiaryRate: espacio.BeneficiaryRate,
                horarios: espacio.Horarios
            ));
        }
        public async Task UpdateHorarioAsync(string id, string idHorario, HorarioEspacio horario)
        {
            var filter = Builders<Espacio>.Filter.Where(e => e.Id == id && e.Horarios.Any(h => h.Id == idHorario));
            var update = Builders<Espacio>.Update.Set(e => e.Horarios[-1], horario);
            await _espacios.UpdateOneAsync(filter, update);
            //Envío de evento a Kafka
            await kafkaProducer.SendHorarioEvent(new HorarioEvent(
                eventType: EspacioEventType.ESPACIO_HORARIO_UPDATED,
                id: horario.Id,
                EspacioId: id,
                availavility: horario.Availavility,
                startTime: horario.StartTime,
                endTime: horario.EndTime
            ));
        }

        public async Task DeleteEspacioAsync(string id)
        {
            await _espacios.DeleteOneAsync(espacio => espacio.Id == id);
            //Envío de evento a Kafka
            await kafkaProducer.SendEspacioEvent(new EspacioEvent(
                eventType: EspacioEventType.ESPACIO_DELETED,
                id: id
            ));
        }
        public async Task DeleteHorarioAsync(string id, string idHorario)
        {
            var filter = Builders<Espacio>.Filter.Eq(e => e.Id, id);
            var update = Builders<Espacio>.Update.PullFilter(e => e.Horarios, h => h.Id == idHorario);
            await _espacios.UpdateOneAsync(filter, update);
            //Envío de evento a Kafka
            await kafkaProducer.SendHorarioEvent(new HorarioEvent(
                eventType: EspacioEventType.ESPACIO_HORARIO_DELETED,
                id: idHorario,
                EspacioId: id 
            ));
        }
    }
}