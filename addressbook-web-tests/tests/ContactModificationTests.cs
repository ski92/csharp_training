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

            List<ContactData> oldContactNames = app.Contacts.GetContactNamesLists();
            List<ContactData> oldContactLastNames = app.Contacts.GetContactLastnamesLists();

            app.Contacts.Modify(2, newData);

            List<ContactData> newContactNames = app.Contacts.GetContactNamesLists();
            List<ContactData> newContactLastnames = app.Contacts.GetContactLastnamesLists();

            oldContactNames[0].Firstname = newData.Firstname;
            oldContactLastNames[0].Lastname = newData.Lastname;
            oldContactNames.Sort();
            oldContactLastNames.Sort();
            newContactNames.Sort();
            newContactLastnames.Sort();
            Assert.AreEqual(oldContactNames, newContactNames);
            Assert.AreEqual(oldContactLastNames, newContactLastnames);
        }
    }
}
