using System;

namespace WebAddressbookTests
{
    public class ContactsData : IEquatable<ContactsData>, IComparable<ContactsData>
    {
        private string allPhones;
        private string allEmail;

        public ContactsData()
        {            
        }

        public override string ToString()
        {
            return "\nFirstname=" + Firstname + "\nLastname=" + Lastname;
        }

        public bool Equals(ContactsData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname && Lastname == other.Lastname;
        }

        public override int GetHashCode()
        {
            return 0;
        }

        public int CompareTo(ContactsData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Lastname.CompareTo(other.Lastname) == 0)
            {
                return Firstname.CompareTo(other.Firstname);
            }
            return Lastname.CompareTo(other.Lastname);
        }

        public ContactsData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;            
        }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int ID { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }
        public string HomePhone2 { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanupPhone(HomePhone)+ CleanupPhone(MobilePhone)+ CleanupPhone(WorkPhone) + CleanupPhone(HomePhone2)).Trim();
                }
                
            }
            set
            {
                allPhones = value;
            }
        }        

        public string AllEmail
        {
            get
            {
                if (allEmail != null)
                {
                    return allEmail;
                }
                else
                {                    
                    return (CleanupEmail(Email) + CleanupEmail(Email2) + CleanupEmail(Email3)).Trim();
                }
            }
            set
            {
                allEmail = value;
            }
        }

        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }

        public string ContactDetails { get; set; }

        private string CleanupPhone(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }
        private string CleanupEmail(string email)
        {
            if (email == null || email == "")
            {
                return "";
            }
            return email + "\r\n";
        }
    }
}
