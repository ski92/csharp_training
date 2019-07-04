﻿using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            GroupData group = new GroupData("aaa");
            group.Header = "sss";
            group.Footer = "ddd";

            List<GroupData> oldGroups = app.Groups.GetGroupLists();

            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupLists();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGroupLists();

            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupLists();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }

        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a'");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroups = app.Groups.GetGroupLists();

            app.Groups.Create(group);

            List<GroupData> newGroups = app.Groups.GetGroupLists();
            Assert.AreEqual(oldGroups.Count + 1, newGroups.Count);
        }
    }
}
