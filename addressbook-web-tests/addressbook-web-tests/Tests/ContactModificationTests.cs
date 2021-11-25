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
            int contact_index = 2;
            while (!app.Contact.IsContactPresent(contact_index+1))
            {
                ContactsData contact = new ContactsData() { Firstname = "Johnn", Lastname = "Dow" };
                app.Contact.Create(contact);
            }
            ContactsData new_data = new ContactsData() { Firstname = "Jane", Lastname = "Parkins" };
            

            List<ContactsData> oldContacts = app.Contact.GetContactList();
            ContactsData oldData = oldContacts[contact_index];

            app.Contact.Modify(contact_index, new_data);

            List<ContactsData> newContacts = app.Contact.GetContactList();

            Assert.AreEqual(oldContacts.Count, app.Contact.GetContactCount());

            oldData.Lastname = new_data.Lastname;
            oldData.Firstname = new_data.Firstname;

            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactsData contact in newContacts)
            {
                if (contact.ID == oldData.ID)
                {
                    Assert.AreEqual(oldData.Lastname, contact.Lastname);
                    Assert.AreEqual(oldData.Firstname, contact.Firstname);                    
                }
            }
        }
    }
}