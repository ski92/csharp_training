using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using WebAddressbookTests;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            string format = args[2];
            string dataType = args[3];

            List<GroupData> groups = new List<GroupData>();
            List<ContactData> contacts = new List<ContactData>();

            for (int i = 0; i < count; i++)
            {
                if (dataType == "groups")
                {

                    groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                    {
                        Header = TestBase.GenerateRandomString(100),
                        Footer = TestBase.GenerateRandomString(100)
                    });
                }
                else if (dataType == "contacts")
                {
                    contacts.Add(new ContactData(TestBase.GenerateRandomString(10))
                    {
                        Lastname = TestBase.GenerateRandomString(10),
                        Address = TestBase.GenerateRandomString(10),
                        MobilePhone = TestBase.GenerateRandomString(10),
                        Email_1 = TestBase.GenerateRandomString(10),
                        Email_2 = TestBase.GenerateRandomString(10),
                        Email_3 = TestBase.GenerateRandomString(10),
                        HomePhone = TestBase.GenerateRandomString(10),
                        WorkPhone = TestBase.GenerateRandomString(10),
                        AllPhones = TestBase.GenerateRandomString(10),
                        AllEmails = TestBase.GenerateRandomString(10),
                    });
                }
                else
                {
                    System.Console.Out.Write("Unrecognized data type: \"" + dataType + "\"");
                }
            }
            if (format == "csv")
            {
                WriteGroupsToCsvFile(groups, writer);
            }
            if (format == "xml" && dataType == "groups")
            {
                WriteGroupsToXmlFile(groups, writer);
            }
            if (format == "xml" && dataType == "contacts")
            {
                WriteContactsToXmlFile(contacts, writer);
            }
            else if (format == "json" && dataType == "groups")
            {
                WriteGroupsToJsonFile(groups, writer);
            }
            else if (format == "json" && dataType == "contacts")
            {
                WriteContactsToJsonFile(contacts, writer);
            }
            else
            {
                System.Console.Out.Write("Unrecognized format: \"" + format);
            }
            writer.Close();
        }

        static void WriteGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                group.Name, group.Header, group.Footer));
            }
        }
        static void WriteGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }
        private static void WriteContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }
        static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }
        static void WriteContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }
    }
}
