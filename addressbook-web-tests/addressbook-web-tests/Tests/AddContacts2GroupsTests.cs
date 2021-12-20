using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddContacts2GroupsTests : AuthTestBase
    {
        [Test]
        public void AddingContact2Group()
        {
            
            if (GroupData.GetAllGroups().Count == 0)
            {
                GroupData group_to_add = new GroupData(GenerateRandomString(10));
                app.Group.Create(group_to_add);
                Console.Out.WriteLine("Extra group created");
            }
            GroupData group = GroupData.GetAllGroups()[0];

            List<ContactsData> oldList = group.GetContacts();
            
            while (!ContactsData.GetAllContacts().Except(oldList).Any())
            {
                ContactsData contactToAdd = new ContactsData(GenerateRandomString(6), GenerateRandomString(8));
                app.Contact.Create(contactToAdd);
                Console.Out.WriteLine("Extra contact created");
            }

            ContactsData contact = ContactsData.GetAllContacts().Except(oldList).First();

            app.Contact.AddContact2Group(contact, group);

            List<ContactsData> newList = group.GetContacts();
            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
