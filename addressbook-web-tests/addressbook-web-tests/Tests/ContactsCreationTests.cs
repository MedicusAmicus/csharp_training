﻿using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {         
            ContactsData contact = new ContactsData("Johnn", "Dow");

            List<ContactsData> oldContacts = app.Contact.GetContactList();

            app.Contact.Create(contact);

            List<ContactsData> newContacts = app.Contact.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }    
    }
}
