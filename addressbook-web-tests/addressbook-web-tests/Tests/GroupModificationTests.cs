using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public  class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModifyTest()
        {
            GroupData new_data = new GroupData("GroupMod");
            new_data.Header = null;
            new_data.Footer = null;

            app.Group.Modify(3, new_data);            
        }
    }
}
