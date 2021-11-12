using NUnit.Framework;

namespace WebAddressbookTests 
{
    [TestFixture]
    class GroupRemovalTests: AuthTestBase
    {
        [Test]        
        public void GroupRemovalTest()
        {
            int group_index = 1;
            while (!app.Group.IsGroupPresent(group_index))
            {
                GroupData group = new GroupData("Group");
                group.Header = "head";
                group.Footer = "foo";

                app.Group.Create(group);
            }
            app.Navigator.GotoGroupsPage();
            app.Group.Remove(group_index);
        }
    }
}
 