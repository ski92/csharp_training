using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            GroupData group = new GroupData("aaa");
            group.Header = "sss";
            group.Footer = "ddd";
            app.Groups.CreateIfListIsEmpty(group);

            List<GroupData> oldGroups = app.Groups.GetGroupLists();

            app.Groups.RemoveGroup(0);

            List<GroupData> newGroups = app.Groups.GetGroupLists();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
