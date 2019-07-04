using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            ContactData contact = new ContactData("Andrew");
            contact.Lastname = "Test";
            app.Contacts.CreateIfTableIsEmpty(contact);

            List<ContactData> oldContactNames = app.Contacts.GetContactNamesLists();
            List<ContactData> oldContactLastNames = app.Contacts.GetContactLastnamesLists();

            app.Contacts.RemoveContact(0);

            List<ContactData> newContactNames = app.Contacts.GetContactNamesLists();
            List<ContactData> newContactLastnames = app.Contacts.GetContactLastnamesLists();

            oldContactNames.RemoveAt(0);
            oldContactLastNames.RemoveAt(0);

            Assert.AreEqual(oldContactNames, newContactNames);
            Assert.AreEqual(oldContactLastNames, newContactLastnames);
        }
    }
}

