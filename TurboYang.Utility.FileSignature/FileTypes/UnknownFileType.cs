using System;

namespace TurboYang.Utility.FileType.FileTypes
{
    public sealed class UnknownFileType : FileType
    {
        internal UnknownFileType() 
            : base(String.Empty, "Unknown", null)
        {
        }
    }
}
