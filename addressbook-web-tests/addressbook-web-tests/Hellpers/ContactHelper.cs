using System;
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
        }
        
        public ContactHelper Update()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper ModifyContact(int contact_number)
        {
            manager.Navigator.GotoModificationContactPage(contact_number);
            return this;
        }

        public ContactHelper SelectContact(int contact_number)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + contact_number + "]")).Click();
            return this;
        }        

        public void GotoContactsPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }


        public ContactHelper Submit()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }       
    }
}
