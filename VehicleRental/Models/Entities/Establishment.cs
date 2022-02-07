using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace VehicleRental.Models.Entities
{
    public class Establishment
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRequired]
        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonRequired]
        [BsonElement("Phones")]
        public List<string> Phones { get; set; }

        [BsonRequired]
        [BsonElement("Emails")]
        public List<string> Emails { get; set; }

        [BsonElement("CreatedAt")]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [BsonElement("UpdatedAt")]
        public DateTime? UpdatedAt { get; set; }

        //location
    }
}
