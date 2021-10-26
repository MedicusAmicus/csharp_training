using NUnit.Framework;

namespace WebAddressbookTests 
{
    [TestFixture]
    class GroupRemovalTests: TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            navigator.OpenHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            navigator.GotoGroupsPage();
            groupHelper.SelectGroup(1);
            groupHelper.RemoveGroup();
            groupHelper.ReturnToGroupsPage();
        }
    }
}
 