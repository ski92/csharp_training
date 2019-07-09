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

            if (!app.Groups.IsGroupsExist())
            {
                app.Groups.Create(group);
            }

            List<GroupData> oldGroups = app.Groups.GetGroupLists();

            app.Groups.RemoveGroup(0);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount());

            List<GroupData> newGroups = app.Groups.GetGroupLists();

            GroupData toBeRemoved = oldGroups[0];

            oldGroups.RemoveAt(0);

            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData newGroup in newGroups)
            {
                Assert.AreNotEqual(newGroup.Id, toBeRemoved.Id);
            }
        }
    }
}
