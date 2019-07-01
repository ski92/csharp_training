using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {

        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("Qwerty");
            newData.Lastname = "Asd";
            app.Contacts.Modify(2, newData);
        }
    }
}
