using Microsoft.Extensions.Options;
using MongoDB.Driver;
using VehicleRental.Infrastructure;
using VehicleRental.Models.Contracts;
using VehicleRental.Models.Entities;

namespace VehicleRental.Models.Services
{
    public class VehicleService : IVehicleService
    {

        private readonly MongoDBOptions _options;
        private readonly IMongoCollection<Vehicle> _vehicle;
        private const string CollectionName = "Vehicle";

        public VehicleService(IOptions<MongoDBOptions> options)
        {
            _options = options.Value;
            var client = new MongoClient(_options.ConnnectionString);
            var database = client.GetDatabase(_options.DatabaseName);
            _vehicle = database.GetCollection<Vehicle>(CollectionName);
        }

        public async Task<Vehicle> Register(Vehicle vehicle)
        {
            await _vehicle.InsertOneAsync(vehicle);
            return vehicle;
        }
        public async Task Rent(string id, string userId) 
        {
            //TODO
            var update = Builders<Vehicle>.Update
                .Set(v => v.RentedAt, DateTime.Now)
                .Set(v => v.UserId, userId);

            await _vehicle.UpdateOneAsync(v => v.Id == id, update);
        }

        public async Task Remove(string id)
        {
            await _vehicle.DeleteOneAsync(v => v.Id == id);
        }

        public async Task<Vehicle> Find(string id)
        {
            var filters = Builders<Vehicle>.Filter.Eq(v => v.Id, id);

            return await _vehicle.Find(filters).SingleOrDefaultAsync();
        }

        public async Task<(long count, List<Vehicle> vehicles)> List()
        {
            var filters = Builders<Vehicle>.Filter.Empty;

            var count = await _vehicle.CountDocumentsAsync(filters);
            var vehicles =  await _vehicle.Find(filters).ToListAsync();

            return (count, vehicles);
        }

        public async Task GiveBack(string id, string userId)
        {
            var update = Builders<Vehicle>.Update
                .Set(v => v.GiveBackAt, DateTime.Now)
                .Set(v => v.LastUserId, userId)
                .Set(v => v.RentedAt, null)
                .Set(v => v.UserId, null);

            await _vehicle.UpdateOneAsync(v => v.Id == id, update);
        }
    }
}
