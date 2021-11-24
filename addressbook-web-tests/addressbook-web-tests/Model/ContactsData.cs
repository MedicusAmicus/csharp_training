using System;

namespace WebAddressbookTests
{
    public class ContactsData : IEquatable<ContactsData>, IComparable<ContactsData>
    {
        private string allPhones;
        private string allEmail;

        public ContactsData(string firstname)
        {
            Firstname = firstname;
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

        public ContactsData(string firstname, string lastname, int Id)
        {
            Firstname = firstname;
            Lastname = lastname;
            ID = Id;
        }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int ID { get; set; }

        public string Address { get; set; }

        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string WorkPhone { get; set; }

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
                    return (Cleanup(HomePhone)+ "\r\n" + Cleanup(MobilePhone)+ "\r\n" + Cleanup(WorkPhone)).Trim();
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
                    return (Email + "\r\n" + Email2 + "\r\n" + Email3).Trim();
                }

            }
            set
            {
                allPhones = value;
            }
        }

        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Email3 { get; set; }

        private string Cleanup(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n";
        }
    }
}
