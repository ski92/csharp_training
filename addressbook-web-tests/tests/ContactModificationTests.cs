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
            ContactData contact = new ContactData("Andrew", "Test");

            if (!app.Contacts.IsContactsExist())
            {
                app.Contacts.Create(contact);
            }

            ContactData newData = new ContactData("Qwerty", "Asd");

            List<ContactData> oldContactNames = app.Contacts.GetContactsLists();

            app.Contacts.Modify(0, newData);

            List<ContactData> newContactNames = app.Contacts.GetContactsLists();

            oldContactNames[0].Firstname = newData.Firstname;
            oldContactNames[0].Lastname = newData.Lastname;

            oldContactNames.Sort();
            newContactNames.Sort();

            Assert.AreEqual(oldContactNames, newContactNames);
        }
    }
}
