using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithvValidCredentials()
        {
            AccountData account = new AccountData("admin", "secret");

            app.Auth.Logout();

            app.Auth.Login(account);
            Assert.IsTrue(app.Auth.IsloggedIn(account));
        }
        [Test]
        public void LoginWithInvalidCredentials()
        {
            AccountData account = new AccountData("admin", "123");

            app.Auth.Logout();

            app.Auth.Login(account);
            Assert.IsFalse(app.Auth.IsloggedIn(account));
        }
    }
}
