using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : ContactTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {
            ContactData contact = new ContactData("Andrew", "Test");

            if (!app.Contacts.IsContactsExist())
            {
                app.Contacts.Create(contact);
            }

            List<ContactData> oldContactNames = ContactData.GetAll();

            ContactData toBeRemoved = ContactData.GetAll().First();

            app.Contacts.Remove(toBeRemoved);

            ContactData item = oldContactNames.Find(c => c.Id == toBeRemoved.Id);

            List<ContactData> newContactNames = ContactData.GetAll();

            int i = oldContactNames.IndexOf(item);
            oldContactNames.RemoveAt(i);

            //Assert.AreEqual(oldContactNames, newContactNames);

            foreach (ContactData newContact in newContactNames)
            {
                Assert.AreNotEqual(newContact.Id, toBeRemoved.Id);
            }
        }
    }
}

