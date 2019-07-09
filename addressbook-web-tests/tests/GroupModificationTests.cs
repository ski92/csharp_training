using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]

        public void GroupModificationTest()
        {
            GroupData group = new GroupData("aaa");
            group.Header = "sss";
            group.Footer = "ddd";

            if (!app.Groups.IsGroupsExist())
            {
                app.Groups.Create(group);
            }

            GroupData newData = new GroupData("bbb");
            newData.Header = "zzz";
            newData.Footer = "hhh";

            List<GroupData> oldGroups = app.Groups.GetGroupLists();

            app.Groups.Modify(0, newData);

            List<GroupData> newGroups = app.Groups.GetGroupLists();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
