using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemoveFromMainPageTest()
        {
            int contact_index = 2;
            while (!app.Contact.IsContactPresent(contact_index))
            {
                ContactsData contact = new ContactsData("Johnn", "Dow");
                app.Contact.Create(contact);
            }
            app.Contact.RemoveFromMainPage(2);
        }
        [Test]
        public void ContactRemoveFromEditPageTest()
        {
            int contact_index = 2;
            while (!app.Contact.IsContactPresent(contact_index))
            {
                ContactsData contact = new ContactsData("Johnn", "Dow");
                app.Contact.Create(contact);
            }
            app.Contact.RemoveFromModifyPage(2);
        }
    }
}
