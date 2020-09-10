using System;
using System.Collections.Generic;
using System.Text;
using TurboYang.Utility.FileSignature.Matchers;

namespace TurboYang.Utility.FileSignature.Signatures
{
    public class Jpg : Signature
    {
        public Jpg()
            : base(".jpg", "JPEG Image", "image/jpeg", new GeneralMatcher(
                new List<(Int32 Offset, Byte?[] MagicNumber)>()
                {
                    (0, new Byte?[] { 0xFF, 0xD8 })
                })
            )
        {
        }
    }
}
