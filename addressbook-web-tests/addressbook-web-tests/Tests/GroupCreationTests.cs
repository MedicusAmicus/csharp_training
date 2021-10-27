using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GotoGroupsPage();
            app.Groups.InitGroupCreation();
            GroupData group = new GroupData("Group");
            group.Header = "head";
            group.Footer = "foo";
            app.Groups.FillGroupCreationForm(group);
            app.Groups.Submit();
            app.Groups.ReturnToGroupsPage();
            app.Auth.Logout();
        }             
    }
}
