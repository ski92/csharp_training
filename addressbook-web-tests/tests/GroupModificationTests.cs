using NUnit.Framework;

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
            app.Groups.CreateIfListIsEmpty(group);
            GroupData newData = new GroupData("bbb");
            newData.Header = "zzz";
            newData.Footer = "hhh";

            app.Groups.Modify(0, newData); 
        }
    }
}
