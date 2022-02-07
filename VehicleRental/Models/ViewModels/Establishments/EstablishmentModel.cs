using VehicleRental.Models.Entities;

namespace VehicleRental.Models.ViewModels.Establishments
{
    public class EstablishmentModel
    {
        public string Name { get; set; }
        public List<string> Phones { get; set; }
        public List<string> Emails { get; set; }

        public Establishment Map() => new Establishment
        {
            Name = Name,
            Phones = Phones,
            Emails = Emails
        };
    }
}
