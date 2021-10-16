using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class UserCreationTests : CommonData
    {
        [Test]
        public void UserCreationTest()
        {
            OpenHomePage();
            Login(new AccountData("admin", "secret"));
            GotoUsersPage();
            UserData user = new UserData("Johnn", "Dow");
            FillUserCreationForm(user);
            Submit();
            ReturnToHomepage();
            logout();
        }
        
        private void FillUserCreationForm(UserData user)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(user.Firstname);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(user.Lastname);
        }

        private void GotoUsersPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }        
    }
}
