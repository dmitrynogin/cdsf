# Cds.Folders library

## OSPath class

Converting paths from/to Windows backward slashes is a pretty monotonous task. Here is a library class to help with it.

    OSPath path = @"/foo\bar.txt";
        
    // Windows output
    WriteLine(path);            // \foo\bar.txt
    WriteLine(path.Windows);    // \foo\bar.txt
    WriteLine(path.Unix);       // /foo/bar.txt

    // MacOS output
    WriteLine(path);            // /foo/bar.txt
    WriteLine(path.Windows);    // \foo\bar.txt
    WriteLine(path.Unix);       // /foo/bar.txt

It also helps converting between relative and absolute paths:

    OSPath ap = "/foo/bar";
    WriteLine(ap.Relative.Unix); // foo/bar
    WriteLine(ap.Absolute.Unix); // /foo/bar

    OSPath rp = "foo/bar";
    WriteLine(rp.Relative.Unix); // foo/bar
    WriteLine(rp.Absolute.Unix); // /foo/bar

And to perform path arithmetic (Windows output):

    OSPath root = @"/foo\bar";
    WriteLine(root + "file.txt");        // \foo\bar\file.txt
    WriteLine(root + "file.txt" - root); // file.txt

