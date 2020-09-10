using System;
using System.Collections.Generic;
using System.Text;
using TurboYang.Utility.FileSignature.Matchers;

namespace TurboYang.Utility.FileSignature.Signatures
{
    public class Tif : Signature
    {
        public Tif()
            : base(".tif", "Tagged Image File Format File", "image/tiff", new GeneralMatcher(
                new List<(Int32 Offset, Byte?[] MagicNumber)>()
                {
                    (0, new Byte?[] { 0x49, 0x49, 0x2A, 0x00 })
                })
            )
        {
        }
    }
}
