using SedesService.Model;
using SedesService.Properties;
using System.Text;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MongoDB.Bson;

namespace SedesService.Service
{
    public class SedesServiceImp
    {
        private readonly IMongoCollection<Sede> _sedes;

        public SedesServiceImp(IOptions<SedesDatabaseSettings> sedesDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                sedesDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                sedesDatabaseSettings.Value.DatabaseName);

            _sedes = mongoDatabase.GetCollection<Sede>(
                sedesDatabaseSettings.Value.CollectionName);
        }

        public async Task<List<Sede>> GetSedesAsync()
        {
            return await _sedes.Find(sede => true).ToListAsync();
        }

        public async Task<Sede> GetSedeByIdAsync(ObjectId id)
        {
            return await _sedes.Find(sede => sede.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateSedeAsync(Sede sede)
        {
            await _sedes.InsertOneAsync(sede);
        }

        public async Task UpdateSedeAsync(ObjectId id, Sede sede)
        {
            await _sedes.ReplaceOneAsync(s => s.Id == id, sede);
        }

        public async Task DeleteSedeAsync(ObjectId id)
        {
            await _sedes.DeleteOneAsync(sede => sede.Id == id);
        }
    }
}