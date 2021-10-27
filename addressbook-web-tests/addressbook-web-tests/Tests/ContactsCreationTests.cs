using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Contacts.GotoUContactsPage();
            ContactsData contact = new ContactsData("Johnn", "Dow");
            app.Contacts.FillContactsCreationForm(contact);
            app.Contacts.Submit();
            app.Navigator.ReturnToHomepage();
            app.Auth.Logout();
        }    
    }
}
