namespace MichaelBrandonMorris.AllianceReservationsTest
{
    public class Company : Entity<Company>, IAddress
    {
        public Company(string name, Address address)
        {
            Name = name;
            Address = address;
        }

        public string Name { get; set; }
        public Address Address { get; set; }
    }
}