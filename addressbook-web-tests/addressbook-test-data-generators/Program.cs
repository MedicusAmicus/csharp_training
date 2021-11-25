using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace WebAddressbookTests
{
    class Program
    {
        static void Main(string[] args)
        {
            string target = args[1].Split('.')[0];
            string format = args[1].Split('.')[1];
            int count = Convert.ToInt32(args[0]);
            string filename = target + '.' + format;
            string path = "c:\\Users\\User\\source\\repos\\MedicusAmicus\\csharp_training" +
                "\\addressbook-web-tests\\addressbook-web-tests\\"; //не хочу ручками копировать

            /*
            string target = args[0];
            int count = Convert.ToInt32(args[1]);
            string filename = args[2];
            string path = "c:\\Users\\User\\source\\repos\\MedicusAmicus\\csharp_training" +
                "\\addressbook-web-tests\\addressbook-web-tests\\"; 
            string format = args[3];
            */


            if (target == "groups")
            {
                WriteGroupDataFile(count, filename, path, format);                
            }
            else if (target == "contacts")
            {
                WriteContactDataFile(count, filename, path, format);                
            }
            else
            {
                Console.Out.Write("Unrecognized target: " + target + ". Valid targets are: \"groups\", \"contacts\"");
            }
        }

        private static void WriteGroupDataFile(int count, string filename, string path, string format)
        {
            if (format == "csv" || format == "xml" || format == "json")
            {
                List<GroupData> groups = new List<GroupData>();
                StreamWriter writer = new StreamWriter(path + filename);
                for (int i = 0; i < count; i++)
                {
                    groups.Add(new GroupData()
                    {
                        Name = TestBase.GenerateRandomString(10),
                        Header = TestBase.GenerateRandomString(20),
                        Footer = TestBase.GenerateRandomString(20)
                    });
                }

                if (format == "csv")
                {
                    WriteGroupsToCsvFile(groups, writer);
                    Console.Out.Write("Done!");
                }
                else if (format == "xml")
                {
                    WriteGroupsToXmlFile(groups, writer);
                    Console.Out.Write("Done!");
                }
                else if (format == "json")
                {
                    WriteGroupsToJsonFile(groups, writer);
                    Console.Out.Write("Done!");
                }
                writer.Close();
            }
            else
            {
                Console.Out.Write("Unrecognized format: " + format + ". Available formats are: *.csv, *.xml, *.json");
            }            
        }

        private static void WriteContactDataFile(int count, string filename, string path, string format)
        {

            if (format == "csv" || format == "xml" || format == "json")
            {
                List<ContactsData> contacts = new List<ContactsData>();
                StreamWriter writer = new StreamWriter(path + filename);
                for (int i = 0; i < count; i++)
                {
                    contacts.Add(new ContactsData()
                    {
                        Firstname = TestBase.GenerateRandomString(10),
                        Lastname = TestBase.GenerateRandomString(20)
                    });
                }

                if (format == "xml")
                {
                    WriteContactsToXmlFile(contacts, writer);
                    Console.Out.Write("Done!");
                }
                else if (format == "json")
                {
                    WriteContactsToJsonFile(contacts, writer);
                    Console.Out.Write("Done!");
                }                
                writer.Close();
            }
            else
            {
                Console.Out.Write("Unrecognized format: " + format + ". Available formats are: *.csv, *.xml, *.json");
            }

        }

        static void WriteGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name,
                    group.Header,
                    group.Footer
                    ));
            }
        }
        static void WriteGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }
        static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Formatting.Indented));            
        }

        
        static void WriteContactsToXmlFile(List<ContactsData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactsData>)).Serialize(writer, contacts);
        }
        static void WriteContactsToJsonFile(List<ContactsData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Formatting.Indented));            
        }
    }
}
