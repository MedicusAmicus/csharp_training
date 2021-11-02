﻿namespace WebAddressbookTests
{
    public class ContactsData
    {
        private string firstname;
        private string lastname;        

        public ContactsData(string firstname)
        {
            this.firstname = firstname;
        }
        public ContactsData(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;            
        }
        public string Firstname
        {
            get
            {
                return firstname;
            }
            set
            {
                firstname = value;
            }
        }
        public string Lastname
        {
            get
            {
                return lastname;
            }
            set
            {
                lastname = value;
            }
        }        
    }
}
