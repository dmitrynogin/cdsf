using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cds.Folders.Tests
{
    [TestClass]
    public class FolderFile_Should
    {
        [TestMethod]
        public void Expose_Path()
        {
            var file = new Folder("c:\\root")
                .AsRoot()
                .Down("foo")
                .File("bar.txt");

            Assert.AreEqual("c:\\root\\foo\\bar.txt", file.FullPath.Windows);
            Assert.AreEqual("foo\\bar.txt", file.Path.Windows);
        }
    }
}
