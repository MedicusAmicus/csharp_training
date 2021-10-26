using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {        
        private string baseURL;

        public NavigationHelper(IWebDriver driver, string baseURL) : base(driver)        
        {            
            this.baseURL = baseURL;
        }
        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }
        public void ReturnToHomepage()
        {
            driver.FindElement(By.LinkText("home")).Click();
        }
        public void GotoGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

    }
}
