using Cds.Folders;
using System;
using static System.Console;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            PathDemo();
            FolderDemo();
        }

        private static void FolderDemo()
        {
            var folder = Folder.OfAssembly<Program>()
                .AsRoot()
                .Down("Test");

            WriteLine(folder.FullPath);
            WriteLine(folder.Path);
        }

        static void PathDemo()
        {
            OSPath path = @"/foo\bar.txt";

            // Windows output
            WriteLine(path);            // \foo\bar.txt
            WriteLine(path.Windows);    // \foo\bar.txt
            WriteLine(path.Unix);       // /foo/bar.txt

            // MacOS output
            WriteLine(path);            // /foo/bar.txt
            WriteLine(path.Windows);    // \foo\bar.txt
            WriteLine(path.Unix);       // /foo/bar.txt

            // It also helpes converting between relative and absolute paths:

            OSPath ap = "/foo/bar";
            WriteLine(ap.Relative.Unix); // foo/bar
            WriteLine(ap.Absolute.Unix); // /foo/bar

            OSPath rp = "/foo/bar";
            WriteLine(rp.Relative.Unix); // foo/bar
            WriteLine(rp.Absolute.Unix); // /foo/bar

            // And to perform path arithmetics (Windows output):
            OSPath root = @"/foo\bar";
            WriteLine(root + "file.txt");        // \foo\bar\file.txt
            WriteLine(root + "file.txt" - root); // file.txt
        }
    }
}
