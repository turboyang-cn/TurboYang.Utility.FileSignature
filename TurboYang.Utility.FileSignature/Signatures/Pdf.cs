using System;
using System.Collections.Generic;
using System.Text;
using TurboYang.Utility.FileSignature.Matchers;

namespace TurboYang.Utility.FileSignature.Signatures
{
    public class Pdf : Signature
    {
        public Pdf()
            : base(".pdf", "Adobe Acrobat Document", "application/pdf", new GeneralMatcher(
                new List<(Int32 Offset, Byte?[] MagicNumber)>()
                {
                    (0, new Byte?[] { 0x25, 0x50, 0x44, 0x46 })
                })
            )
        {
        }
    }
}
