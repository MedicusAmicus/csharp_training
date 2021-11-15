using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace WebAddressbookTests
{ 
    public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }
        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }
        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);            
            return this;
        }

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }

        private List<GroupData> groupCache = null;


        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();
                manager.Navigator.GotoGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(element.Text));
                }
            }
            
            return new List<GroupData>(groupCache);
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GotoGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            Submit();
            ReturnToGroupsPage();            
            return this;
        }

        public GroupHelper Remove(int group_number)
        {
            manager.Navigator.GotoGroupsPage(); 
            SelectGroup(group_number);
            RemoveGroup();
            ReturnToGroupsPage();          
            return this;
        }


        public GroupHelper Modify(int group_number, GroupData new_data)
        {           
            manager.Navigator.GotoGroupsPage();
            SelectGroup(group_number);
            ModifyGroup();
            FillGroupForm(new_data);
            Update();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }
        public GroupHelper ModifyGroup()
        {
            driver.FindElement(By.Name("edit")).Click();
            groupCache = null;
            return this;
        }

        public GroupHelper SelectGroup(int group_index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (group_index+1) + "]")).Click();
            return this;
        }
        public GroupHelper Submit()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCache = null;
            return this;
        }
        public GroupHelper Update()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
            return this;
        }
        public bool IsGroupPresent(int group_index)
        {
            manager.Navigator.GotoGroupsPage();
            return IsElementPresent(By.XPath("(//input[@name='selected[]'])[" + group_index + "]"));
        }       
    }
}
