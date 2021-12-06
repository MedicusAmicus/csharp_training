using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : ContactsTestBase
    {
        public static IEnumerable<ContactsData> RandomContactDataProvider()
        {
            List<ContactsData> contact = new List<ContactsData>();
            for (int i = 0; i < 3; i++)
            {
                contact.Add(new ContactsData(GenerateRandomString(6), GenerateRandomString(8)));
            }
            return contact;
        }
        public static IEnumerable<ContactsData> ContactDataFromXmlFile()
        {
            return (List<ContactsData>)new XmlSerializer(typeof(List<ContactsData>)).Deserialize(new StreamReader(@"contacts.xml"));
        }
        public static IEnumerable<ContactsData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactsData>>(
                File.ReadAllText(@"contacts.json"));
        }

        [Test, TestCaseSource("ContactDataFromJsonFile")]
        public void ContactCreationTest(ContactsData contact)
        {         
            List<ContactsData> oldContacts = ContactsData.GetAllContacts();

            app.Contact.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contact.GetContactCount());

            List<ContactsData> newContacts = ContactsData.GetAllContacts();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }    
    }
}
