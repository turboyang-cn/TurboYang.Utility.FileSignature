using System;
using System.Collections.Generic;
using System.Text;
using TurboYang.Utility.FileSignature.Matchers;

namespace TurboYang.Utility.FileSignature.Signatures
{
    public class Doc : Signature
    {
        public Doc()
            : base(".doc", "Microsoft Word 97 - 2003 Document", "application/msword", new GeneralMatcher(
                new List<(Int32 Offset, Byte?[] MagicNumber)>()
                {
                    (0, new Byte?[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 }),
                    (512, new Byte?[] { 0xEC, 0xA5, 0xC1, 0x00 })
                })
            )
        {
        }
    }
}
