using System;
using System.Collections.Generic;
using System.Text;
using TurboYang.Utility.FileSignature.Matchers;

namespace TurboYang.Utility.FileSignature.Signatures
{
    public class Rar : Signature
    {
        public Rar()
            : base(".rar", "WinRAR Compressed Archive", String.Empty, new GeneralMatcher(
                new List<(Int32 Offset, Byte?[] MagicNumber)>()
                {
                    (0, new Byte?[] { 0x52, 0x61, 0x72, 0x21, 0x1A, 0x07 })
                })
            )
        {
        }
    }
}
