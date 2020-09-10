using System;
using System.Collections.Generic;
using System.Text;
using TurboYang.Utility.FileSignature.Matchers;

namespace TurboYang.Utility.FileSignature.Signatures
{
    public class Zip : Signature
    {
        public Zip()
            : base(".zip", "PKZIP Compressed Archive", "application/x-zip-compressed", new GeneralMatcher(
                new List<(Int32 Offset, Byte?[] MagicNumber)>()
                {
                    (0, new Byte?[] { 0x50, 0x4B, 0x03, 0x04 })
                })
            )
        {
        }
    }
}
