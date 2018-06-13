using System;

namespace Cds.Folders
{
    public abstract class FolderEntry
    {
        protected FolderEntry(OSPath fullPath, OSPath root)
        {
            FullPath = fullPath;
            Root = root;
        }

        public OSPath FullPath { get; }
        public OSPath Path => FullPath - Root;
        protected OSPath Root { get; }
    }
}
