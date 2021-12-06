using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excell = Microsoft.Office.Interop.Excel;
using System;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : GroupTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i=0; i<5; i++)
            {
                
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
                return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                groups.Add(new GroupData()
                {
                    Name = parts[0],
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            ;
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {            
            return (List<GroupData>) new XmlSerializer(typeof(List<GroupData>)).Deserialize(new StreamReader(@"groups.xml"));             
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(
                File.ReadAllText(@"groups.json"));                
        }

        public static IEnumerable<GroupData> GroupDataFromExcellFile()
        {
            List<GroupData> groups = new List<GroupData>();
            Excell.Application app = new Excell.Application();
            Excell.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(),@"groups.xlsx"));
            Excell.Worksheet sheet = wb.ActiveSheet;
            Excell.Range range = sheet.UsedRange;
            for (int i = 1; i<=range.Rows.Count; i++)
            {
                groups.Add(new GroupData()
                {
                    Name = range.Cells[i, 1].Value,
                    Header = range.Cells[i, 2].Value,
                    Footer = range.Cells[i, 3].Value
                });
            }
            wb.Close();
            app.Quit();
            //app.Visible = false;
            return groups;            
        }

        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void GroupCreationTest(GroupData group)
        {
            List<GroupData> oldGroups = GroupData.GetAllGroups();

            app.Group.Create(group);

            Assert.AreEqual(oldGroups.Count+1, app.Group.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAllGroups();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        /*
        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Group.GetGroupList();

            app.Group.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, app.Group.GetGroupCount());

            List<GroupData> newGroups = app.Group.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
        */  //Тест создания группы с пустым именем

        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = GroupData.GetAllGroups();

            app.Group.Create(group);

            Assert.AreEqual(oldGroups.Count, app.Group.GetGroupCount());
            List<GroupData> newGroups = app.Group.GetGroupList();
            Assert.AreEqual(oldGroups, newGroups);    //group list not changed         
        }


        
        [Test]
        public void TestDBConnection()
        {
            foreach (ContactsData contact in GroupData.GetAllGroups()[1].GetContacts()) 
                {
                Console.Out.WriteLine(contact);
                } 
        }
         //тест соединения с БД
    }
}