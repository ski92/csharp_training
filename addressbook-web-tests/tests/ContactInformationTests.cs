using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void TestContactInformationFromTable()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

        [Test]
        public void TestContactInformationFromCard()
        {
            ContactData fromCard = app.Contacts.GetContactInformationFromCard(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm(0);
            System.Console.Out.Write(("CARD DATA\n" + fromCard.AllData).ToString());
            System.Console.Out.Write(("FORM DATA\n" + fromForm.AllData).ToString());
            Assert.AreEqual(fromCard.AllData, fromForm.AllData);
        }
    }
}
