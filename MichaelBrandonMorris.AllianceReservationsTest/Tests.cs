using NUnit.Framework;

namespace MichaelBrandonMorris.AllianceReservationsTest
{
    public class Tests
    {
        [TestCase]
        public void ProgrammerTest()
        {
            var address = new Address("56 Main St", "Mesa", "AZ", "38574");
            var customer = new Customer("John", "Doe", address);
            var company = new Company("Google", address);

            Assert.That(customer.Id, Is.Null.Or.Empty);
            customer.Save();
            Assert.That(customer.Id, Is.Not.Null.Or.Empty);

            Assert.That(company.Id, Is.Null.Or.Empty);
            company.Save();
            Assert.That(company.Id, Is.Not.Null.Or.Empty);

            Customer savedCustomer = Customer.Find(customer.Id);
            Assert.IsNotNull(savedCustomer);
            Assert.AreSame(customer.Address, address);
            Assert.AreEqual(savedCustomer.Address, address);
            Assert.AreEqual(customer.Id, savedCustomer.Id);
            Assert.AreEqual(customer.FirstName, savedCustomer.FirstName);
            Assert.AreEqual(customer.LastName, savedCustomer.LastName);
            Assert.AreEqual(customer, savedCustomer);
            Assert.AreNotSame(customer, savedCustomer);

            Company savedCompany = Company.Find(company.Id);
            Assert.IsNotNull(savedCompany);
            Assert.AreSame(company.Address, address);
            Assert.AreEqual(savedCompany.Address, address);
            Assert.AreEqual(company.Id, savedCompany.Id);
            Assert.AreEqual(company.Name, savedCompany.Name);
            Assert.AreEqual(company, savedCompany);
            Assert.AreNotSame(company, savedCompany);

            customer.Delete();
            Assert.That(customer.Id, Is.Null.Or.Empty);
            Assert.IsNull(Customer.Find(customer.Id));

            company.Delete();
            Assert.That(company.Id, Is.Null.Or.Empty);
            Assert.IsNull(Company.Find(company.Id));
        }
    }
}
