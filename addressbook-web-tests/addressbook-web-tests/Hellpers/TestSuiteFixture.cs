//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using NUnit.Framework;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;

namespace WebAddressbookTests
{
    [SetUpFixture]
    public class TestSuiteFixture
    {
        public static ApplicationManager app;

        [SetUp]
        public void InitApplicationManager()
        {
            app = new ApplicationManager();
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
        }
        [TearDown]
        public void StopApplicationManager()
        {
            app.Auth.Logout();
            app.Stop();
        }
    }
}
