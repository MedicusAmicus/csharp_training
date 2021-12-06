using NUnit.Framework;
using System.Collections.Generic;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
    {
        [Test]
        public void GroupModifyTest()
        {
            int group_index = 0;
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

            List<GroupData> oldGroups = GroupData.GetAllGroups();
            GroupData oldData = oldGroups[group_index];

            app.Group.Modify(oldData, new_data);

            Assert.AreEqual(oldGroups.Count, app.Group.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAllGroups();
            oldGroups[group_index].Name = new_data.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(new_data.Name, group.Name);
                }
            }
        }
    }
}
