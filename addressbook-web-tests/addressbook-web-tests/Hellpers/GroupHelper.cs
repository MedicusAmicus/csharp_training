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
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
            return this;
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
            return this;
        }
        public GroupHelper ModifyGroup()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int group_index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + group_index + "]")).Click();
            return this;
        }
        public GroupHelper Submit()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
        public GroupHelper Update()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

    }
}
