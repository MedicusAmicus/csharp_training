using OpenQA.Selenium;


namespace WebAddressbookTests
{
    public class HelperBase
    {
        protected IWebDriver driver;

        public HelperBase(IWebDriver driver)
        {
        this.driver = driver;
        }
        public void Submit()
        {
            driver.FindElement(By.Name("submit")).Click();
        }
    }
    
}