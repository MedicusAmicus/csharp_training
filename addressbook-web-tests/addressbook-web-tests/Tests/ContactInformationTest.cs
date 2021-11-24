using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            int contactIndex = 0;

            ContactsData fromTable = app.Contact.GetContactInformationFromTable(contactIndex);
            ContactsData fromEditForm = app.Contact.GetContactInformationFromEditForm(contactIndex);

            Assert.AreEqual(fromTable, fromEditForm);
            Assert.AreEqual(fromTable.Address, fromEditForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromEditForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmail, fromEditForm.AllEmail);
        }

        [Test]
        public void TestDetailContactInformation()
        {
            int contactIndex = 0;

            string fromDetails = app.Contact.GetContactInformationFromDetailTable(contactIndex);
            ContactsData fromEditForm = app.Contact.GetContactInformationFromEditForm(contactIndex);

            Assert.AreEqual(fromDetails, fromEditForm.ContactDetails);            
        }
    }
}