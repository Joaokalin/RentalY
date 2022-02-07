namespace VehicleRental.Models.Entities
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

    }
}
