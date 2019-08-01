using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : ContactTestBase
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

            List<ContactData> oldContactNames = ContactData.GetAll();

            ContactData toBeModified = ContactData.GetAll().First();

            ContactData item = oldContactNames.Find(c => c.Id == toBeModified.Id);

            app.Contacts.ModifyContact(toBeModified, newData);

            List<ContactData> newContactNames = ContactData.GetAll();

            int i = oldContactNames.IndexOf(item);
            oldContactNames[i].Firstname = newData.Firstname;
            oldContactNames[i].Lastname = newData.Lastname;

            oldContactNames.Sort();
            newContactNames.Sort();

            Assert.AreEqual(oldContactNames, newContactNames);
        }
    }
}
