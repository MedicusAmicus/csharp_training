using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            navigator.OpenHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            navigator.GotoGroupsPage();
            groupHelper.InitGroupCreation();
            GroupData group = new GroupData("Group");
            group.Header = "head";
            group.Footer = "foo";
            groupHelper.FillGroupCreationForm(group);
            Submit();
            groupHelper.ReturnToGroupsPage();
            loginHelper.Logout();
        }             
    }
}
