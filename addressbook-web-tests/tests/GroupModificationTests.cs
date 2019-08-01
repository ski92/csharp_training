using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : GroupTestBase
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

            List<GroupData> oldGroups = GroupData.GetAll();
            GroupData oldData = oldGroups[0];

            GroupData toBeModified = oldGroups[0];
            app.Groups.ModifyById(toBeModified, newData);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroups = GroupData.GetAll();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData newGroup in newGroups)
            {
                if (newGroup.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, newGroup.Name);
                }
            }
        }
    }
}
