using System;
using System.Collections.Generic;
using System.Text;
using TurboYang.Utility.FileSignature.Matchers;

namespace TurboYang.Utility.FileSignature.Signatures
{
    public class Bmp : Signature
    {
        public Bmp()
            : base(".bmp", "Bitmap Image", "image/bmp", new GeneralMatcher(
                new List<(Int32 Offset, Byte?[] MagicNumber)>()
                {
                    (0, new Byte?[] { 0x42, 0x4D })
                })
            )
        {
        }
    }
}
