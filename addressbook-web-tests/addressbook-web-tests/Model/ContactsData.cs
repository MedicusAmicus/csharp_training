using System;

namespace WebAddressbookTests
{
    public class ContactsData : IEquatable<ContactsData>, IComparable<ContactsData>
    {        
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

        public ContactsData (string firstname, string lastname, int Id)
        {
            Firstname = firstname;
            Lastname = lastname;
            ID = Id;
        }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int ID { get; set; }
    }
}
