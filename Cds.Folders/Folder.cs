using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cds.Folders
{
    public class Folder : FolderEntry
    {
        public Folder(OSPath fullPath)
            : this(fullPath, OSPath.Empty)
        {
        }

        public Folder(OSPath fullPath, OSPath root) 
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

        public FolderFile File(OSPath path) =>
            new FolderFile(FullPath + path, Root);
    }
}
