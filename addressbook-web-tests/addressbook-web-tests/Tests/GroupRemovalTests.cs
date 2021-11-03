using NUnit.Framework;

namespace WebAddressbookTests 
{
    [TestFixture]
    class GroupRemovalTests: AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            app.Navigator.GotoGroupsPage();
            app.Group.Remove(1);
        }
    }
}
 