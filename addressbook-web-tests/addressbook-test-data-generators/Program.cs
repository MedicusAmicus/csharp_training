using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace WebAddressbookTests
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            string filename = args[1];
            string path = "c:\\Users\\User\\source\\repos\\MedicusAmicus\\csharp_training" +
                "\\addressbook-web-tests\\addressbook-web-tests\\"; //не хочу ручками копировать
            string format = args[2];

            List<GroupData> groups = new List<GroupData>();
            StreamWriter writer = new StreamWriter(path+filename);
            for (int i=0; i<count; i++)
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
            }
            else if (format == "xml")
            {
                WriteGroupsToXmlFile(groups, writer);
            }
            else if (format == "json")
            {
                WriteGroupsToJsonFile(groups, writer);
            }
            else
            {
                Console.Out.Write("Unrecognized format " + format);
            }
            writer.Close();            
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

        }
    }
}
