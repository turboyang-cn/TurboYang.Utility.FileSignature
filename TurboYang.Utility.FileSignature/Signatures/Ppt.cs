using System;
using System.Collections.Generic;
using System.Text;
using TurboYang.Utility.FileSignature.Matchers;

namespace TurboYang.Utility.FileSignature.Signatures
{
    public class Ppt : Signature
    {
        public Ppt()
            : base(".ppt", "Microsoft PowerPoint 97-2003 Presentation", "application/vnd.ms-powerpoint", new GeneralMatcher(
                new List<(Int32 Offset, Byte?[] MagicNumber)>()
                {
                    (0, new Byte?[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 }),
                    (512, new Byte?[] { 0xFD, 0xFF, 0xFF, 0xFF, null, null, 0x00, 0x00 })
                })
            )
        {
        }
    }
}
