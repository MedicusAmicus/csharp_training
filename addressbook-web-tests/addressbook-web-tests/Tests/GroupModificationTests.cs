using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public  class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModifyTest()
        {
            int group_index = 2;
            while (!app.Group.IsGroupPresent(group_index))
            {
                GroupData group = new GroupData("Group");
                group.Header = "head";
                group.Footer = "foo";

                app.Group.Create(group);
            }
            GroupData new_data = new GroupData("GroupMod");
            new_data.Header = null;
            new_data.Footer = null;

            app.Group.Modify(group_index, new_data);            
        }
    }
}
