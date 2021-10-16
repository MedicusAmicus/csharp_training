﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    class UserData
    {
        private string firstname;
        private string lastname;        

        public UserData(string firstname)
        {
            this.firstname = firstname;
        }
        public UserData(string firstname, string lastname)
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
