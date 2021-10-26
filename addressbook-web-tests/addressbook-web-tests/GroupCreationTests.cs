using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GotoGroupsPage();
            InitGroupCreation();
            GroupData group = new GroupData("Group");
            group.Header = "head";
            group.Footer = "foo";
            FillGroupCreationForm(group);
            Submit();
            ReturnToGroupsPage();
            logout();
        }             
    }
}
