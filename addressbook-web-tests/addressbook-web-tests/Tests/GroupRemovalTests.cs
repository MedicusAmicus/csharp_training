﻿using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests 
{
    [TestFixture]
    class GroupRemovalTests: AuthTestBase
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

            List<GroupData> oldGroups = app.Group.GetGroupList();

            app.Group.Remove(group_index);

            Assert.AreEqual(oldGroups.Count - 1, app.Group.GetGroupCount());

            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups.RemoveAt(group_index);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
 