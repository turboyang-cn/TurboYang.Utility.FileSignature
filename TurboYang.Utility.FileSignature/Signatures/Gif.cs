using System;
using System.Collections.Generic;
using System.Text;
using TurboYang.Utility.FileSignature.Matchers;

namespace TurboYang.Utility.FileSignature.Signatures
{
    public class Gif : Signature
    {
        public Gif()
            : base(".gif", "GIF Image", "image/gif", new GeneralMatcher(
                new List<(Int32 Offset, Byte?[] MagicNumber)>()
                {
                    (0, new Byte?[] { 0x47, 0x49, 0x46, 0x38, 0x37, 0x61 })
                },
                new List<(Int32 Offset, Byte?[] MagicNumber)>()
                {
                    (0, new Byte?[] { 0x47, 0x49, 0x46, 0x38, 0x39, 0x61 })
                })
            )
        {
        }
    }
}
