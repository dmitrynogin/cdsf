using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cds.Folders.Tests
{
    [TestClass]
    public class OSPath_Should
    {
        [TestMethod]
        public void Unify_Via_Casting()
        {
            string p1 = (OSPath)"\\foo bar\\file.txt";
            string p2 = (OSPath)"/foo bar/file.txt";
            string expected = OSPath.IsWindows 
                ? "\\foo bar\\file.txt" 
                : "/foo bar/file.txt";

            Assert.AreEqual(expected, p1);
            Assert.AreEqual(expected, p2);
        }

        [TestMethod]
        public void Unify_Rooted_Windows_Path()
        {
            OSPath path = "c:\\foo bar\\file.txt";

            Assert.IsTrue(path.IsAbsolute);
            Assert.IsTrue(path.HasVolume);
            Assert.IsFalse(path.Volumeless.HasVolume);
            Assert.IsTrue(path.Volumeless.IsAbsolute);            
            Assert.AreEqual("\\foo bar\\file.txt", path.Volumeless.Windows);

            Assert.AreEqual("c:\\foo bar\\file.txt", path.Windows);
            Assert.AreEqual("/foo bar/file.txt", path.Unix);
            Assert.AreEqual(
                OSPath.IsWindows ? "c:\\foo bar\\file.txt" : "/foo bar/file.txt",
                path.Normalized);

            Assert.AreEqual("foo bar\\file.txt", path.Relative.Windows);
            Assert.AreEqual("foo bar/file.txt", path.Relative.Unix);
            Assert.AreEqual(
                OSPath.IsWindows ? "foo bar\\file.txt" : "foo bar/file.txt",
                path.Relative.Normalized);

            Assert.AreEqual("\\foo bar\\file.txt", path.Absolute.Windows);
            Assert.AreEqual("/foo bar/file.txt", path.Absolute.Unix);
            Assert.AreEqual(
                OSPath.IsWindows ? "\\foo bar\\file.txt" : "/foo bar/file.txt",
                path.Absolute.Normalized);
        }

        [TestMethod]
        public void Unify_Rootless_Windows_Path()
        {
            OSPath path = "\\foo bar\\file.txt";

            Assert.IsFalse(path.HasVolume);
            Assert.AreEqual("\\foo bar\\file.txt", path.Volumeless.Windows);

            Assert.AreEqual("\\foo bar\\file.txt", path.Windows);
            Assert.AreEqual("/foo bar/file.txt", path.Unix);
            Assert.AreEqual(
                OSPath.IsWindows ? "\\foo bar\\file.txt" : "/foo bar/file.txt",
                path.Normalized);

            Assert.AreEqual("foo bar\\file.txt", path.Relative.Windows);
            Assert.AreEqual("foo bar/file.txt", path.Relative.Unix);
            Assert.AreEqual(
                OSPath.IsWindows ? "foo bar\\file.txt" : "foo bar/file.txt",
                path.Relative.Normalized);

            Assert.AreEqual("\\foo bar\\file.txt", path.Absolute.Windows);
            Assert.AreEqual("/foo bar/file.txt", path.Absolute.Unix);
            Assert.AreEqual(
                OSPath.IsWindows ? "\\foo bar\\file.txt" : "/foo bar/file.txt",
                path.Absolute.Normalized);
        }

        [TestMethod]
        public void Unify_Unix_Path()
        {
            OSPath path = "/foo bar/file.txt";

            Assert.AreEqual("\\foo bar\\file.txt", path.Volumeless.Windows);

            Assert.AreEqual("\\foo bar\\file.txt", path.Windows);
            Assert.AreEqual("/foo bar/file.txt", path.Unix);
            Assert.AreEqual(
                OSPath.IsWindows ? "\\foo bar\\file.txt" : "/foo bar/file.txt",
                path.Normalized);

            Assert.AreEqual("foo bar\\file.txt", path.Relative.Windows);
            Assert.AreEqual("foo bar/file.txt", path.Relative.Unix);
            Assert.AreEqual(
                OSPath.IsWindows ? "foo bar\\file.txt" : "foo bar/file.txt",
                path.Relative.Normalized);

            Assert.AreEqual("\\foo bar\\file.txt", path.Absolute.Windows);
            Assert.AreEqual("/foo bar/file.txt", path.Absolute.Unix);
            Assert.AreEqual(
                OSPath.IsWindows ? "\\foo bar\\file.txt" : "/foo bar/file.txt",
                path.Absolute.Normalized);
        }

        [TestMethod]
        public void Combine()
        {
            OSPath path = "/foo";
            var file = path + "\\bar\\test.txt";
            Assert.AreEqual("/foo/bar/test.txt", file.Unix);
        }

        [TestMethod]
        public void Extract_Local_Path()
        {
            OSPath path = "/foo/bar/test.txt";
            var file = path - "\\foo";
            Assert.AreEqual("bar/test.txt", file.Unix);
        }
    }
}
