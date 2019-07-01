using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]

        public void GroupModificationTest()
        {
            GroupData newData = new GroupData("bbb");
            newData.Header = "zzz";
            newData.Footer = "hhh";

            app.Groups.Modify(1, newData); 
        }
    }
}
