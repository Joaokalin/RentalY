using VehicleRental.Models.Entities;

namespace VehicleRental.Models.Contracts
{
    public interface IVehicleService
    {
        Task<Vehicle> Register(Vehicle vehicle);
        Task Rent(string id, string userId);
        Task Remove(string id);
        Task<Vehicle> Find(string id);
        Task<(long count, List<Vehicle> vehicles)> List();
        Task GiveBack(string id, string userId);
    }
}
