using System;
using System.Collections.Generic;
using System.Text;

namespace Cds.Folders
{
    public class FolderFile : FolderEntry
    {
        public FolderFile(OSPath fullPath, string root = "")
            : base(fullPath, root)
        {            
        }
    }
}
