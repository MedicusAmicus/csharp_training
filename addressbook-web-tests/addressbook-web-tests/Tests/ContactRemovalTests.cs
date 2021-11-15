﻿using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemoveFromMainPageTest()
        {
            int contact_index = 0;
            while (!app.Contact.IsContactPresent(contact_index+1))
            {
                ContactsData contact = new ContactsData("Johnn", "Dow");
                app.Contact.Create(contact);
            }

            List<ContactsData> oldContacts = app.Contact.GetContactList();

            app.Contact.RemoveFromMainPage(contact_index);

            List<ContactsData> newContacts = app.Contact.GetContactList();
            oldContacts.RemoveAt(contact_index);
            Assert.AreEqual(oldContacts, newContacts);
        }
        [Test]
        public void ContactRemoveFromEditPageTest()
        {
            int contact_index = 0;
            while (!app.Contact.IsContactPresent(contact_index+1))
            {
                ContactsData contact = new ContactsData("Johnn", "Dow");
                app.Contact.Create(contact);
            }
            List<ContactsData> oldContacts = app.Contact.GetContactList();

            app.Contact.RemoveFromModifyPage(contact_index+1);

            List<ContactsData> newContacts = app.Contact.GetContactList();

            oldContacts.RemoveAt(contact_index);
            Assert.AreEqual(oldContacts, newContacts);            
        }
    }
}
