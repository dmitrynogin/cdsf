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
    }
}
