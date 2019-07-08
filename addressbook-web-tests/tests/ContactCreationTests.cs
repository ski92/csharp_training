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

            List<ContactData> oldContactNames = app.Contacts.GetContactsLists();

            app.Contacts.Create(contact);

            List<ContactData> newContactNames = app.Contacts.GetContactsLists();

            oldContactNames.Add(contact);

            oldContactNames.Sort();
            newContactNames.Sort();

            Assert.AreEqual(oldContactNames, newContactNames);
        }

        [Test]
        public void EmptyContactCreationTest()
        {
            ContactData contact = new ContactData("");
            contact.Lastname = "";

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

