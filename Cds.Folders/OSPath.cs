﻿using System;
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

        public OSPath(string text)
        {
            Text = text.Trim();
        }

        public static implicit operator OSPath(string text) => text == null ? null : new OSPath(text);
        public static implicit operator string(OSPath path) => path?.Normalized;
        public override string ToString() => Normalized;

        protected string Text { get; }

        public string Normalized => IsWindows ? Windows : Unix;
        public string Windows => Text.Replace('/', '\\');
        public string Unix => Simplified.Text.Replace('\\', '/');

        public OSPath Relative => Simplified.Text.TrimStart('/', '\\');
        public OSPath Absolute => IsAbsolute ? this : "/" + Relative;

        public bool IsAbsolute => IsRooted || HasVolume;
        public bool IsRooted => Text.Length >= 1 && (Text[0] == '/' || Text[0] == '\\');
        public bool HasVolume => Text.Length >= 2 && Text[1] == ':';
        public OSPath Simplified => HasVolume ? Text.Substring(2) : Text;

        public OSPath Parent => GetDirectoryName(Text);

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
