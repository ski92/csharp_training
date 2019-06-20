using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("Andrew");
            contact.Lastname = "Test";
            app.Contacts
                .GoToAddNewPage()
                .FillContactForm(contact)
                .SubmitContactCreation()
                .ReturnToHomePage();
        }
    }
}
