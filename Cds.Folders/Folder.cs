using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cds.Folders
{
    public class Folder : FolderEntry
    {
        public Folder(OSPath fullPath, string root = "") 
            : base(fullPath, root)
        {
        }

        public Folder AsRoot() => new Folder(FullPath, FullPath);

        public Folder Down(string folder) => 
            new Folder(FullPath + folder, Root);

        public Folder Up() =>
            new Folder(FullPath.Parent, Root);

        public void Create() =>
            Directory.CreateDirectory(FullPath.Normalized);
    }
}
