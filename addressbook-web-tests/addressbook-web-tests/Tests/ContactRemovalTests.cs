using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemoveFromMainPageTest()
        {
            app.Contact.RemoveFromMainPage(2);
        }
        [Test]
        public void ContactRemoveFromEditPageTest()
        {
            app.Contact.RemoveFromModifyPage(2);
        }
    }
}
