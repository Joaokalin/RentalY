using Microsoft.Extensions.Options;
using MongoDB.Driver;
using VehicleRental.Infrastructure;
using VehicleRental.Models.Contracts;
using VehicleRental.Models.Entities;

namespace VehicleRental.Models.Services
{
    public class EstablishmentService : IEstablishmentService
    {
        private readonly MongoDBOptions _options;
        private readonly IMongoCollection<Establishment> _establishment;
        private const string CollectionName = "Establishment";

        public EstablishmentService(IOptions<MongoDBOptions> options)
        {
            _options = options.Value;
            var client = new MongoClient(_options.ConnnectionString);
            var database = client.GetDatabase(_options.DatabaseName);
            _establishment = database.GetCollection<Establishment>(CollectionName);
        }

        public async Task<Establishment> Register(Establishment establishment)
        {
            await _establishment.InsertOneAsync(establishment);
            return establishment;
        }

        public async Task<Establishment> Update(Establishment establishment)
        {
            var update = Builders<Establishment>.Update
                .Set(est => est.UpdatedAt, DateTime.Now);

            await _establishment.UpdateOneAsync(item => item.Id == establishment.Id, update);

            return establishment;
        }

        public async Task<List<Establishment>> List()
        {
            var filters = Builders<Establishment>.Filter.Empty;

            return await _establishment.Find(filters).ToListAsync();
        }

        public async Task<Establishment> Find(string id)
        {
            var filters = Builders<Establishment>.Filter.Eq(est => est.Id, id);

            return await _establishment.Find(filters).SingleOrDefaultAsync();
            
        }
    }
}
