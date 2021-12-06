using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : ContactsTestBase
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

            List<ContactsData> oldContacts = ContactsData.GetAllContacts();
            ContactsData ToBeModified = oldContacts[contact_index];

            app.Contact.Modify(ToBeModified.ID, new_data);

            List<ContactsData> newContacts = ContactsData.GetAllContacts();

            Assert.AreEqual(oldContacts.Count, app.Contact.GetContactCount());

            ToBeModified.Lastname = new_data.Lastname;
            ToBeModified.Firstname = new_data.Firstname;

            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactsData contact in newContacts)
            {
                if (contact.ID == ToBeModified.ID)
                {
                    Assert.AreEqual(ToBeModified.Lastname, contact.Lastname);
                    Assert.AreEqual(ToBeModified.Firstname, contact.Firstname);                    
                }
            }
        }
    }
}