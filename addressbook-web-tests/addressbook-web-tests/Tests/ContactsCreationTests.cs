﻿using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactsData> RandomContactDataProvider()
        {
            List<ContactsData> contact = new List<ContactsData>();
            for (int i = 0; i < 3; i++)
            {
                contact.Add(new ContactsData(GenerateRandomString(6), GenerateRandomString(8)));
            }
            return contact;
        }
        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(ContactsData contact)
        {         
            List<ContactsData> oldContacts = app.Contact.GetContactList();

            app.Contact.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contact.GetContactCount());

            List<ContactsData> newContacts = app.Contact.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }    
    }
}
