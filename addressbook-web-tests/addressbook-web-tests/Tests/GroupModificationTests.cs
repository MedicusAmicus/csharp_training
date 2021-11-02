using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public  class GroupModificationTests : TestBase
    {
        [Test]
        public void GroupModifyTest()
        {
            GroupData new_data = new GroupData("Group2");
            new_data.Header = "header";
            new_data.Footer = "footer";

            app.Group.Modify(2, new_data);            
        }
    }
}
