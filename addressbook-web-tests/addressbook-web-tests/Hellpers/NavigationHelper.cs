using System;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class NavigationHelper : HelperBase
    {        
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL) : base(manager)
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
        public void GotoContactsPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
        public void GotoModificationContactPage(int contact_number)
        {
            int contact_id = int.Parse(s: driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (contact_number+1) + "]")).GetProperty("id"));
            driver.Navigate().GoToUrl(baseURL + "/edit.php?id=" + contact_id);
        }

        public void GotoModificationContactPage(string contact_number)
        {
            driver.Navigate().GoToUrl(baseURL + "/edit.php?id=" + contact_number);
        }
        public void AlertAccept()
        {
            driver.SwitchTo().Alert().Accept();
        }

        public void GoToDetailsPage(int contact_number)
        {
            int contact_id = int.Parse(s: driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (contact_number + 1) + "]")).GetProperty("id"));
            driver.Navigate().GoToUrl(baseURL + "/view.php?id=" + contact_id);
        }
    }
}