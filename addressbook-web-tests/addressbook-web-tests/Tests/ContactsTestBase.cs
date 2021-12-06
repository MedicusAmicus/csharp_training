using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class ContactsTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareContactsUi_DB()
        {
            if (Perform_Long_Ui_Checks)
            {
                List<ContactsData> fromUI = app.Contact.GetContactList();
                List<ContactsData> fromDb = ContactsData.GetAllContacts();
                fromUI.Sort();
                fromDb.Sort();
                Assert.AreEqual(fromUI, fromDb);
            }
        }
    }
}