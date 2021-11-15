using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModifyTest()
        {
            int contact_index = 0;
            while (!app.Contact.IsContactPresent(contact_index+1))
            {
                ContactsData contact = new ContactsData("Johnn", "Dow");
                app.Contact.Create(contact);
            }
            ContactsData new_data = new ContactsData("Jane");
            new_data.Lastname = "Parkins";

            List<ContactsData> oldContacts = app.Contact.GetContactList();

            app.Contact.Modify(contact_index, new_data);

            List<ContactsData> newContacts = app.Contact.GetContactList();

            oldContacts[contact_index].Lastname = new_data.Lastname;
            oldContacts[contact_index].Firstname = new_data.Firstname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}