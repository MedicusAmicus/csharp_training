using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace WebAddressbookTests
{
    [TestFixture]
    class GroupCreationTests : AuthTestBase
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
            return (List<GroupData>)new XmlSerializer(typeof(List<GroupData>)).Deserialize(new StreamReader(@"groups.json"));
        }

        [Test, TestCaseSource("GroupDataFromXmlFile")]
        public void GroupCreationTest(GroupData group)
        {
            List<GroupData> oldGroups = app.Group.GetGroupList();

            app.Group.Create(group);

            Assert.AreEqual(oldGroups.Count+1, app.Group.GetGroupCount());

            List<GroupData> newGroups = app.Group.GetGroupList();
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
        */

        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Group.GetGroupList();

            app.Group.Create(group);

            Assert.AreEqual(oldGroups.Count, app.Group.GetGroupCount());
            List<GroupData> newGroups = app.Group.GetGroupList();
            Assert.AreEqual(oldGroups, newGroups);    //group list not changed         
        }
    }
}