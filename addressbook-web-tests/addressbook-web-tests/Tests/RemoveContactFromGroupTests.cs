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
            int contact_index = 15;
            int group_index = 9;
            while (GroupData.GetAllGroups().Count < group_index+1) // создадим группу, если нет под выбранным индексом
            {
                GroupData group_to_add = new GroupData(GenerateRandomString(10));
                app.Group.Create(group_to_add);
            }
            GroupData group = GroupData.GetAllGroups()[group_index];
            List<ContactsData> oldList = group.GetContacts();

            while (oldList.Count <= contact_index + 1) // на случай, если в группе не хватает контактов - добавим до quantum satis
            {
                while (!ContactsData.GetAllContacts().Except(oldList).Any())
                {
                    ContactsData contactToAdd = new ContactsData(GenerateRandomString(6), GenerateRandomString(8));
                    app.Contact.Create(contactToAdd);
                    Console.Out.WriteLine("Extra contact created");
                }
                app.Contact.AddContact2Group(ContactsData.GetAllContacts().Except(oldList).First(), group);
                oldList = group.GetContacts();
            }

            ContactsData contactToRemove = oldList[contact_index];

            app.Contact.RemoveContactFromGroup(contactToRemove, group);

            List<ContactsData> newList = group.GetContacts();
            oldList.Remove(contactToRemove);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}
