using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace VehicleRental.Models.Entities
{
    public class Vehicle
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRequired]
        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonRequired]
        [BsonElement("Brand")]
        public string Brand { get; set; }

        [BsonRequired]
        [BsonElement("Price")]
        public long Price { get; set; }

        [BsonElement("AddedAt")]
        public DateTime AddedAt { get; set; } = DateTime.Now;

        [BsonRequired]
        [BsonElement("LaunchAt")]
        public DateTime LaunchAt { get; set; }

        [BsonElement("RentedAt")]
        public DateTime? RentedAt { get; set; }

        [BsonElement("GiveBackAt")]
        public DateTime? GiveBackAt { get; set; }

        [BsonElement("UserId")]
        public string? UserId { get; set; }

        [BsonElement("LastUserId")]
        public string? LastUserId { get; set; }

    }
}
