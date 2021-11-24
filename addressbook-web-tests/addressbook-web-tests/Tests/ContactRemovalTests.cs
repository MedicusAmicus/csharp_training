using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
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

            List<ContactsData> oldContacts = app.Contact.GetContactList();
            ContactsData oldData = oldContacts[contact_index];

            app.Contact.RemoveFromMainPage(contact_index);

            Assert.AreEqual(oldContacts.Count - 1, app.Contact.GetContactCount());

            List<ContactsData> newContacts = app.Contact.GetContactList();
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
            List<ContactsData> oldContacts = app.Contact.GetContactList();
            ContactsData oldData = oldContacts[contact_index];

            app.Contact.RemoveFromModifyPage(contact_index);

            Assert.AreEqual(oldContacts.Count - 1, app.Contact.GetContactCount());

            List<ContactsData> newContacts = app.Contact.GetContactList();

            oldContacts.RemoveAt(contact_index+1);

            Assert.AreEqual(oldContacts, newContacts);            
        }
    }
}
