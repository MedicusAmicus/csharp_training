using OpenQA.Selenium;

namespace WebAddressbookTests
{ 
    public class GroupHelper
    {
        private IWebDriver driver;

        public GroupHelper(IWebDriver driver)
        {
            this.driver = driver;
        }
        public void InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
        }
        public void FillGroupCreationForm(GroupData group)
        {
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
        }
        public void ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }
        public void RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
        }
        public void SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
        }
    }
}
