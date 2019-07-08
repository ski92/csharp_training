using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {

        [Test]
        public void ContactModificationTest()
        {
            ContactData contact = new ContactData("Andrew");
            contact.Lastname = "Test";
            app.Contacts.CreateIfTableIsEmpty(contact);

            ContactData newData = new ContactData("Qwerty");
            newData.Lastname = "Asd";

            List<ContactData> oldContactNames = app.Contacts.GetContactsLists();

            app.Contacts.Modify(0, newData);

            List<ContactData> newContactNames = app.Contacts.GetContactsLists();

            oldContactNames[0].Firstname = newData.Firstname;

            oldContactNames.Sort();
            newContactNames.Sort();

            Assert.AreEqual(oldContactNames, newContactNames);
        }
    }
}
