using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {            
            GroupData group = new GroupData("Group");
            group.Header = "head";
            group.Footer = "foo";

            app.Group.Create(group);            
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";
            
            app.Group.Create(group);           
        }        
    }
}
