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
            int contact_index = 4;
            GroupData group = GroupData.GetAllGroups()[0];
            List<ContactsData> oldList = group.GetContacts();

            while (oldList.Count <= contact_index + 1) // на случай, если в группе не хватает контактов - добавим до quantum satis
            {
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
