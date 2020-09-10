using System;
using System.Collections.Generic;
using System.Text;
using TurboYang.Utility.FileSignature.Matchers;

namespace TurboYang.Utility.FileSignature.Signatures
{
    public class Xlsx : Signature
    {
        public Xlsx()
            : base(".xlsx", "Microsoft Excel Worksheet", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", new OfficeOpenXmlMatcher(
                new List<(Int32 Offset, Byte?[] MagicNumber)>()
                {
                    (0, new Byte?[] { 0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x06, 0x00 })
                }, "/xl/")
            )
        {
        }
    }
}
