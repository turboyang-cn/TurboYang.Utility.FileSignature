using System;
using System.Collections.Generic;
using System.Text;
using TurboYang.Utility.FileSignature.Matchers;

namespace TurboYang.Utility.FileSignature.Signatures
{
    public class Exe : Signature
    {
        public Exe()
            : base(".exe", "Windows/DOS Executable File", "application/x-msdownload", new GeneralMatcher(
                new List<(Int32 Offset, Byte?[] MagicNumber)>()
                {
                    (0, new Byte?[] { 0x4D, 0x5A }),
                })
            )
        {
        }
    }
}
