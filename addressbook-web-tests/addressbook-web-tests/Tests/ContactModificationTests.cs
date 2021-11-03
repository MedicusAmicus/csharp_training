using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModifyTest()
        {
            ContactsData new_data = new ContactsData("Jane");
            new_data.Lastname = "Parkins";            

            app.Contact.Modify(2, new_data);
        }
    }
}