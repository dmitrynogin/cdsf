using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

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

        public Folder Up() =>
            new Folder(FullPath.Parent, Root);

        public Folder Down(string folder) => 
            new Folder(FullPath + folder, Root);

        public bool Exists =>
            Directory.Exists(FullPath);

        public void Create() =>
            Directory.CreateDirectory(FullPath);

        public FolderFile File(OSPath path) =>
            new FolderFile(FullPath + path, Root);

        public IEnumerable<Folder> Folders() =>
            from fullPath in Directory.EnumerateDirectories(FullPath)
            select new Folder(fullPath, Root);

        public IEnumerable<FolderFile> Files() =>
            from fullPath in Directory.EnumerateFiles(FullPath)
            select new FolderFile(fullPath, Root);
    }
}
