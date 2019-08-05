using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = ContactData.GetAll().Except(group.GetContacts()).First();

            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Add(contact);
            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }

        [Test]
        public void TestRemoveContactFromGroup()
        {
            List<GroupData> groups = GroupData.GetAll();
            for (int i = 0; i < groups.Count(); i++)
            {
                GroupData group = groups[i];
                List<ContactData> oldList = group.GetContacts();

                if (oldList.Count != 0)
                {
                    ContactData contactToRemove = oldList[0];
                    app.Contacts.RemoveContactFromGroup(contactToRemove, group);
                    List<ContactData> newList = group.GetContacts();
                    oldList.Remove(contactToRemove);
                    newList.Sort();
                    oldList.Sort();
                    Assert.AreEqual(oldList, newList);
                }
                else
                {
                    System.Console.Out.WriteLine("There is no contacts in group " + groups[i].Name);
                }
            }
        }
    }
}
