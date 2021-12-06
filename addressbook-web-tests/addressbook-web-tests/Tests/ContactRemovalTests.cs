using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : ContactsTestBase
    {
        [Test]
        public void ContactRemoveFromMainPageTest()
        {
            int contact_index = 5;
            while (!app.Contact.IsContactPresent(contact_index+1))
            {
                ContactsData contact = new ContactsData("Johnn", "Dow");
                app.Contact.Create(contact);
            }

            List<ContactsData> oldContacts = ContactsData.GetAllContacts();
            ContactsData TobeRemoved = oldContacts[contact_index];

            app.Contact.RemoveFromMainPage(TobeRemoved);

            Assert.AreEqual(oldContacts.Count - 1, app.Contact.GetContactCount());

            List<ContactsData> newContacts = ContactsData.GetAllContacts();
            oldContacts.RemoveAt(contact_index);
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void ContactRemoveFromEditPageTest()
        {
            int contact_index = 5;
            while (!app.Contact.IsContactPresent(contact_index+1))
            {
                ContactsData contact = new ContactsData("Johnn", "Dow");
                app.Contact.Create(contact);
            }
            List<ContactsData> oldContacts = ContactsData.GetAllContacts();
            ContactsData TobeRemoved = oldContacts[contact_index];

            app.Contact.RemoveFromModifyPage(TobeRemoved);

            Assert.AreEqual(oldContacts.Count - 1, app.Contact.GetContactCount());

            List<ContactsData> newContacts = ContactsData.GetAllContacts();

            oldContacts.RemoveAt(contact_index);

            Assert.AreEqual(oldContacts, newContacts);            
        }
    }
}
