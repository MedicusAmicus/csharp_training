using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class RemoveContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void RemovingContactFromGroup()
        {
           if (GroupData.GetAllGroups().Count == 0)
            {
                GroupData group_to_add = new GroupData(GenerateRandomString(10));
                app.Group.Create(group_to_add);
            }
            GroupData group = GroupData.GetAllGroups()[0];
            List<ContactsData> oldList = group.GetContacts();

            if (oldList.Count == 0) 
            {
                ContactsData contactToAdd = new ContactsData(GenerateRandomString(6), GenerateRandomString(8));
                app.Contact.Create(contactToAdd);
                Console.Out.WriteLine("Extra contact created");
                
                app.Contact.AddContact2Group(ContactsData.GetAllContacts().Except(oldList).First(), group);
                oldList = group.GetContacts();
            }

            ContactsData contactToRemove = oldList[0];

            app.Contact.RemoveContactFromGroup(contactToRemove, group);

            List<ContactsData> newList = group.GetContacts();
            oldList.Remove(contactToRemove);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
