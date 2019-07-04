using NUnit.Framework;

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
            app.Contacts.Modify(2, newData);
        }
    }
}
