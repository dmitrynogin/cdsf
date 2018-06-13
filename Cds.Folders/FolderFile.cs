using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Cds.Folders
{
    public class FolderFile : FolderEntry
    {
        public FolderFile(OSPath fullPath)
            : this(fullPath, OSPath.Empty)
        {
        }

        public FolderFile(OSPath fullPath, OSPath root)
            : base(fullPath, root)
        {            
        }

        public bool Exists => File.Exists(FullPath);
    }
}
