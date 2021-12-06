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
            GroupData group = GroupData.GetAllGroups()[0];
            List<ContactsData> oldList = group.GetContacts();
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
