using System;
using System.Collections.Generic;
using System.Text;
using TurboYang.Utility.FileSignature.Matchers;

namespace TurboYang.Utility.FileSignature.Signatures
{
    public class Png : Signature
    {
        public Png()
            : base(".png", "PNG Image", "image/png", new GeneralMatcher(
                new List<(Int32 Offset, Byte?[] MagicNumber)>()
                {
                    (0, new Byte?[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A })
                })
            )
        {
        }
    }
}
