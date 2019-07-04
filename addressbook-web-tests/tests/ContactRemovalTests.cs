using NUnit.Framework;

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
            app.Contacts.RemoveContact(1);
        }
    }
}

