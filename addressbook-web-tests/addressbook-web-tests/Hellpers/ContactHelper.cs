
using System.Collections.Generic;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }
        public void FillContactsCreationForm(ContactsData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("lastname"), contact.Lastname);           
        }

        public ContactHelper Create(ContactsData contact)
        {
            manager.Navigator.GotoContactsPage();
            FillContactsCreationForm(contact);
            Submit();
            manager.Navigator.ReturnToHomepage();
            return this;
        }

        public int GetContactCount()
        {
            return driver.FindElements(By.XPath("//table/tbody/tr[@name='entry']")).Count;
        }

        private List<ContactsData> contactsCache = null;

        public List<ContactsData> GetContactList()        
        {
            if (contactsCache == null)
            {
                contactsCache = new List<ContactsData>();
                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//table/tbody/tr[@name='entry']"));
                foreach (IWebElement element in elements)
                {
                    string[] name = element.Text.Split(' ');
                    contactsCache.Add(new ContactsData(name[1], name[0]));
                }
            }
            return new List<ContactsData>(contactsCache);
        }       

        public ContactHelper Modify(int contact_number, ContactsData new_data)
        {            
            ModifyContact(contact_number);
            FillContactsCreationForm(new_data);
            Update();
            manager.Navigator.ReturnToHomepage();
            return this;
        }

        public ContactHelper RemoveFromMainPage(int contact_number)
        {
            SelectContact(contact_number);
            Remove();
            manager.Navigator.AlertAccept(); 
            manager.Navigator.ReturnToHomepage();
            return this;
        }

        public ContactHelper RemoveFromModifyPage(int contact_number)
        {            
            ModifyContact(contact_number);
            Remove();
            manager.Navigator.ReturnToHomepage();
            return this;
        }

        public void Remove()
        {
            driver.FindElement(By.XPath("(//input[@value='Delete'])")).Click();
            contactsCache = null;
        }
        
        public ContactHelper Update()
        {
            driver.FindElement(By.Name("update")).Click();
            contactsCache = null;
            return this;
        }

        public ContactHelper ModifyContact(int contact_number)
        {
            manager.Navigator.GotoModificationContactPage(contact_number);
            return this;
        }

        public ContactHelper SelectContact(int contact_number)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (contact_number+1) + "]")).Click();
            return this;
        }        

        public void GotoContactsPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }


        public ContactHelper Submit()
        {
            driver.FindElement(By.Name("submit")).Click();
            contactsCache = null;
            return this;
        }

        public bool IsContactPresent(int ItemIndex)
        {
            return IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + ItemIndex + "]"));
        }
    }
}
