namespace MichaelBrandonMorris.AllianceReservationsTest
{
    public class Customer : Entity<Customer>, IAddress
    {
        public Customer(string firstName, string lastName, Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
    }
}