using NUnit.Framework;

namespace WebAddressbookTests 
{
    [TestFixture]
    class GroupRemovalTests: TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Navigator.GotoGroupsPage();
            app.Group.Remove(1);
        }
    }
}
 