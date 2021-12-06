using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class GroupTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareGroupsUi_DB()
        {
            if (Perform_Long_Ui_Checks)
            {
            List<GroupData> fromUI = app.Group.GetGroupList();
            List<GroupData> fromDb = GroupData.GetAllGroups();
            fromUI.Sort();
            fromDb.Sort();
            Assert.AreEqual(fromUI, fromDb);
            }
        }
    }
}
