namespace MichaelBrandonMorris.AllianceReservationsTest
{
    public class Address : Entity<Address>
    {
        public Address(string street, string city, string state, string zip)
        {
            Street = street;
            State = state;
            City = city;
            Zip = zip;
        }

        public string City { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
    }
}