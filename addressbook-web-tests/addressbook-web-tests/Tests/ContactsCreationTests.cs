using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {         
            ContactsData contact = new ContactsData("Johnn", "Dow");

            app.Contact.Create(contact);
        }    
    }
}
