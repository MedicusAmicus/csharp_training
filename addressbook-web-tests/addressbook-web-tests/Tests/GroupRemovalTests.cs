using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests 
{
    [TestFixture]
    public class GroupRemovalTests: GroupTestBase
    {
        [Test]        
        public void GroupRemovalTest()
        {
            int group_index = 0;
            while (!app.Group.IsGroupPresent(group_index+1))
            {
                GroupData group = new GroupData("Group");
                group.Header = "head";
                group.Footer = "foo";
                app.Group.Create(group);
            }

            List<GroupData> oldGroups = GroupData.GetAllGroups();
            GroupData toBeRemoved = oldGroups[group_index];
            
            app.Group.Remove(toBeRemoved);

            Assert.AreEqual(oldGroups.Count - 1, app.Group.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAllGroups();
                        
            oldGroups.RemoveAt(group_index);
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }
    }
}
 