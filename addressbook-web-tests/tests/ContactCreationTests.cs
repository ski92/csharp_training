using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30))
                {
                    Firstname = GenerateRandomString(100),
                    Lastname = GenerateRandomString(100)
                });
            }
            return contacts;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(ContactData contact)
        {
            List<ContactData> oldContactNames = app.Contacts.GetContactsLists();

            app.Contacts.Create(contact);

            List<ContactData> newContactNames = app.Contacts.GetContactsLists();

            oldContactNames.Add(contact);

            oldContactNames.Sort();
            newContactNames.Sort();

            Assert.AreEqual(oldContactNames, newContactNames);
        }
    }
}

