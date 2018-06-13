using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using static System.IO.Path;

namespace Cds.Folders
{
    public class OSPath
    {
        public static readonly OSPath Empty = "";

        public static bool IsWindows => DirectorySeparatorChar == '\\';

        public OSPath(string path)
        {
            Path = path.Trim();
        }

        public static implicit operator OSPath(string path) => new OSPath(path);
        public static implicit operator string(OSPath path) => path.Normalized;
        public override string ToString() => Normalized;

        protected string Path { get; }

        public string Normalized => IsWindows ? Windows : Unix;
        public string Windows => Path.Replace('/', '\\');
        public string Unix => Volumeless.Path.Replace('\\', '/');

        public OSPath Relative => Volumeless.Path.TrimStart('/', '\\');
        public OSPath Absolute => IsAbsolute ? this : "/" + Relative;

        public bool IsAbsolute => IsPathRooted(Path);
        public bool HasVolume => IsAbsolute && Path[1] == ':';
        public OSPath Volumeless => HasVolume
            ? (this - GetPathRoot(Path)).Absolute
            : this;

        public OSPath Parent => GetDirectoryName(Path);

        public bool Contains(OSPath path) =>
            Normalized.StartsWith(path);

        public static OSPath operator +(OSPath left, OSPath right) =>
            new OSPath(Combine(left, right.Relative));

        public static OSPath operator -(OSPath left, OSPath right) =>
            left.Contains(right)
            ? new OSPath(left.Normalized.Substring(right.Normalized.Length)).Relative
            : left;
    }
}
