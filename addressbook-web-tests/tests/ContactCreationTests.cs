using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Andrew");
            contact.Lastname = "Test";

            List<ContactData> oldContactNames = app.Contacts.GetContactNamesLists();
            List<ContactData> oldContactLastNames = app.Contacts.GetContactLastnamesLists();

            app.Contacts.Create(contact);

            List<ContactData> newContactNames = app.Contacts.GetContactNamesLists();
            List<ContactData> newContactLastnames = app.Contacts.GetContactLastnamesLists();

            oldContactNames.Add(contact);
            oldContactLastNames.Add(contact);
            oldContactNames.Sort();
            oldContactLastNames.Sort();
            newContactNames.Sort();
            newContactLastnames.Sort();
            Assert.AreEqual(oldContactNames, newContactNames);
            Assert.AreEqual(oldContactLastNames, newContactLastnames);
        }
        
        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("");
            contact.Lastname = "";

            List<ContactData> oldContactNames = app.Contacts.GetContactNamesLists();
            List<ContactData> oldContactLastNames = app.Contacts.GetContactLastnamesLists();

            app.Contacts.Create(contact);

            List<ContactData> newContactNames = app.Contacts.GetContactNamesLists();
            List<ContactData> newContactLastnames = app.Contacts.GetContactLastnamesLists();

            oldContactNames.Add(contact);
            oldContactLastNames.Add(contact);
            oldContactNames.Sort();
            oldContactLastNames.Sort();
            newContactNames.Sort();
            newContactLastnames.Sort();
            Assert.AreEqual(oldContactNames, newContactNames);
            Assert.AreEqual(oldContactLastNames, newContactLastnames);
        }
    }
}

