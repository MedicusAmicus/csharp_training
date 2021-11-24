
using System.Collections.Generic;
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

        public ContactsData GetContactInformationFromEditForm(int contactIndex)
        {
            manager.Navigator.ReturnToHomepage();
            ModifyContact(contactIndex);

            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string homePhone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            string homepage = driver.FindElement(By.Name("homepage")).GetAttribute("value");
            string birthday = getContactBirthday();
            string anniversary = getAnniversary();
            string sec_Address = driver.FindElement(By.Name("address2")).Text; 
            string notes = driver.FindElement(By.Name("notes")).Text; 

            
            string contactDetails = firstName + ' ' + middleName + ' ' + lastName + "\r\n" + nickName + "\r\n" 
                + title + "\r\n" + company + "\r\n" + address + "\r\n\r\nH: " + homePhone +  "\r\nM: " + mobilePhone + "\r\nW: "
                + workPhone + "\r\nF: " + fax + "\r\n\r\n" + email + "\r\n" + email2 + "\r\n" + email3 + "\r\nHomepage:\r\n" 
                + homepage + "\r\n\r\nBirthday " + birthday + "\r\nAnniversary " + anniversary + "\r\n\r\n" 
                + sec_Address + "\r\n\r\nP: " + homePhone2 + "\r\n\r\n" + notes;

            return new ContactsData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                HomePhone2 = homePhone2,
                Email = email,
                Email2 = email2,
                Email3 = email3,
                ContactDetails = contactDetails
            };

        }

        private string getContactBirthday()
        {
            string day = driver.FindElement(By.Name("bday")).Text.Split('\r')[0].Trim();             
            string month = driver.FindElement(By.Name("bmonth")).Text.Split('\r')[0].Trim();
            string year = driver.FindElement(By.Name("byear")).GetAttribute("value").Trim();

            string date = day + ". " + month + " " + year;
            return date;
        }

        private string getAnniversary()
        {
            string day = driver.FindElement(By.Name("aday")).Text.Split('\r')[0].Trim();
            string month = driver.FindElement(By.Name("amonth")).Text.Split('\r')[0].Trim();
            string year = driver.FindElement(By.Name("ayear")).GetAttribute("value").Trim();

            string date = day + ". " + month + " " + year;
            return date;
        }

        public string GetContactInformationFromDetailTable(int contactIndex)
        {
            manager.Navigator.ReturnToHomepage();
            manager.Navigator.GoToDetailsPage(contactIndex); 

            return driver.FindElement(By.XPath("(//*[@id='content'])")).Text; 
        }
        
       
        public ContactsData GetContactInformationFromTable(int contactIndex)
        {
            manager.Navigator.ReturnToHomepage();
            IList<IWebElement> contact = driver.FindElements(By.Name("entry"))[contactIndex].FindElements(By.TagName("td"));
            string lastName = contact[1].Text;
            string firstName = contact[2].Text;
            string address = contact[3].Text;
            string allEmail = contact[4].Text;
            string allPhones = contact[5].Text;

            return new ContactsData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmail = allEmail               
            };
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
            return driver.FindElements(By.Name("entry")).Count;
        }

        private List<ContactsData> contactsCache = null;



        public List<ContactsData> GetContactList()        
        {
            if (contactsCache == null)
            {
                contactsCache = new List<ContactsData>();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                
                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> contact = element.FindElements(By.TagName("td"));

                    string firstname = contact[2].Text;
                    string lastname = contact[1].Text;
                    int Id = Convert.ToInt32(element.FindElement(By.TagName("input")).GetAttribute("value")); 

                    contactsCache.Add(new ContactsData(firstname, lastname) {ID = Id});
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
