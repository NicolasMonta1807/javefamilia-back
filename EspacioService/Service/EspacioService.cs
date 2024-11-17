using EspacioService.Model;
using EspacioService.Properties;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace EspacioService.Service;

public class EspacioService
{
    private readonly IMongoCollection<Espacio> _espacios;

    public EspacioService(IOptions<EspaciosDatabaseSettings> espacioDatabaseSettings)
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
        for (var i = 0; i < espacio.Horarios.Count; i++) espacio.Horarios[i].Id = ObjectId.GenerateNewId().ToString();
        await _espacios.InsertOneAsync(espacio);
    }

    public async Task AddHorarioAsync(string id, HorarioEspacio horario)
    {
        horario.Id = ObjectId.GenerateNewId().ToString();
        var filter = Builders<Espacio>.Filter.Eq(e => e.Id, id);
        var update = Builders<Espacio>.Update.Push(e => e.Horarios, horario);
        await _espacios.UpdateOneAsync(filter, update);
    }

    public async Task UpdateEspacioAsync(string id, Espacio espacio)
    {
        await _espacios.ReplaceOneAsync(e => e.Id == id, espacio);
    }

    public async Task UpdateHorarioAsync(string id, string idHorario, HorarioEspacio horario)
    {
        var filter = Builders<Espacio>.Filter.Where(e => e.Id == id && e.Horarios.Any(h => h.Id == idHorario));
        var update = Builders<Espacio>.Update.Set(e => e.Horarios[-1], horario);
        await _espacios.UpdateOneAsync(filter, update);
    }

    public async Task DeleteEspacioAsync(string id)
    {
        await _espacios.DeleteOneAsync(espacio => espacio.Id == id);
    }

    public async Task DeleteHorarioAsync(string id, string idHorario)
    {
        var filter = Builders<Espacio>.Filter.Eq(e => e.Id, id);
        var update = Builders<Espacio>.Update.PullFilter(e => e.Horarios, h => h.Id == idHorario);
        await _espacios.UpdateOneAsync(filter, update);
    }
}