using NUnit.Framework;
using System.Collections.Generic;


namespace WebAddressbookTests
{
    [TestFixture]
    public  class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModifyTest()
        {
            int group_index = 1;
            while (!app.Group.IsGroupPresent(group_index+1))
            {
                GroupData group = new GroupData("Group");
                group.Header = "head";
                group.Footer = "foo";

                app.Group.Create(group);
            }
            GroupData new_data = new GroupData("GroupMod3");
            new_data.Header = "";
            new_data.Footer = "";

            List<GroupData> oldGroups = app.Group.GetGroupList();

            app.Group.Modify(group_index, new_data);

            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups[group_index].Name = new_data.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);            
        }
    }
}
