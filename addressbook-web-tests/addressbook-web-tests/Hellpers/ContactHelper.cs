using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class ContactHelper
    {
        private IWebDriver driver;

        public ContactHelper(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void FillContactsCreationForm(ContactsData contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
        }
        public void GotoUContactsPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
    }
}
