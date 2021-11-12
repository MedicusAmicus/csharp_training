using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModifyTest()
        {
            int contact_index = 3;
            while (!app.Contact.IsContactPresent(contact_index))
            {
                ContactsData contact = new ContactsData("Johnn", "Dow");
                app.Contact.Create(contact);
            }
            ContactsData new_data = new ContactsData("Jane");
            new_data.Lastname = "Parkins";            

            app.Contact.Modify(contact_index, new_data);
        }
    }
}