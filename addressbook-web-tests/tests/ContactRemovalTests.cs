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
            ContactData contact = new ContactData("Andrew", "Test");
            app.Contacts.CreateIfTableIsEmpty(contact);

            List<ContactData> oldContactNames = app.Contacts.GetContactsLists();

            app.Contacts.RemoveContact(0);

            List<ContactData> newContactNames = app.Contacts.GetContactsLists();

            oldContactNames.RemoveAt(0);

            Assert.AreEqual(oldContactNames, newContactNames);
        }
    }
}

