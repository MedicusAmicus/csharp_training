using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            navigator.OpenHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            contactHelper.GotoUContactsPage();
            ContactsData contact = new ContactsData("Johnn", "Dow");
            contactHelper.FillContactsCreationForm(contact);
            contactHelper.Submit();
            navigator.ReturnToHomepage();
            loginHelper.Logout();
        }    
    }
}
