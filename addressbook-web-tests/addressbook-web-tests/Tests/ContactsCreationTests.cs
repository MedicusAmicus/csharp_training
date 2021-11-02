using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {         
            ContactsData contact = new ContactsData("Johnn", "Dow");

            app.Contact.Create(contact);
        }    
    }
}
