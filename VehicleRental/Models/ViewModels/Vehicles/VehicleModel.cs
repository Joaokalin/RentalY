using VehicleRental.Models.Entities;

namespace VehicleRental.Models.ViewModels.Vehicles
{
    public class VehicleModel
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public long Price { get; set; }
        public DateTime LaunchAt { get; set; }

        public Vehicle Map() => new Vehicle
        {
            Name = Name,
            Brand = Brand,
            Price = Price,
            LaunchAt = LaunchAt
        };
    }
}
