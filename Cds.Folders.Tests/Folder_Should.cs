using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cds.Folders.Tests
{
    [TestClass]
    public class Folder_Should
    {
        [TestMethod]
        public void Navigate()
        {
            var dir = new Folder("/foo/bar")
                .Up()
                .AsRoot()
                .Down("dir");

            Assert.AreEqual("/foo/dir", dir.FullPath.Unix);
            Assert.AreEqual("dir", dir.Path.Unix);
        }

        [TestMethod]
        public void Check_Existence()
        {
            var folder = new Folder("/");
            Assert.IsTrue(folder.Exists);
            Assert.IsFalse(folder.Down("No Such Thing").Exists);
        }
    }
}
