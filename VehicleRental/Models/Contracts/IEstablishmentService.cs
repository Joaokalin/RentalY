using VehicleRental.Models.Entities;

namespace VehicleRental.Models.Contracts
{
    public interface IEstablishmentService
    {
        Task<Establishment> Register(Establishment establishment);
        Task<Establishment> Update(Establishment establishment);
        Task<Establishment> Find(string id);
        Task<List<Establishment>> List();
    }
}
