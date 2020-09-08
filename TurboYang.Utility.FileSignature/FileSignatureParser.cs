using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TurboYang.Utility.FileSignature.Matchers;

namespace TurboYang.Utility.FileSignature
{
    public class FileSignatureParser
    {
        public List<Signature> KnownSignature { get; set; } = new List<Signature>()
        {
            new Signature(".bmp", "Bitmap Image", "image/bmp", new GeneralMatcher(new List<(Int32 Offset, Byte?[] MagicNumber)>()
            {
                (0, new Byte?[] { 0x42, 0x4D })
            })),
            new Signature(".gif", "GIF Image", "image/gif", new GeneralMatcher(new List<(Int32 Offset, Byte?[] MagicNumber)>()
            {
                (0, new Byte?[] { 0x47, 0x49, 0x46, 0x38, 0x37, 0x61 })
            })),
            new Signature(".gif", "GIF Image", "image/gif", new GeneralMatcher(new List<(Int32 Offset, Byte?[] MagicNumber)>()
            {
                (0, new Byte?[] { 0x47, 0x49, 0x46, 0x38, 0x39, 0x61 })
            })),
            new Signature(".jpg", "JPEG Image", "image/jpeg", new GeneralMatcher(new List<(Int32 Offset, Byte?[] MagicNumber)>()
            {
                (0, new Byte?[] { 0xFF, 0xD8 })
            })),
            new Signature(".png", "PNG Image", "image/png", new GeneralMatcher(new List<(Int32 Offset, Byte?[] MagicNumber)>()
            {
                (0, new Byte?[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A })
            })),
            new Signature(".tif", "Tagged Image File Format File", "image/tiff", new GeneralMatcher(new List<(Int32 Offset, Byte?[] MagicNumber)>()
            {
                (0, new Byte?[] { 0x49, 0x49, 0x2A, 0x00 })
            })),
            new Signature(".wmv", "Windows Media Audio/Video File", "video/x-ms-wmv", new GeneralMatcher(new List<(Int32 Offset, Byte?[] MagicNumber)>()
            {
                (0, new Byte?[] { 0x30, 0x26, 0xB2, 0x75, 0x8E, 0x66, 0xCF, 0x11, 0xA6, 0xD9, 0x00, 0xAA, 0x00, 0x62, 0xCE, 0x6C })
            })),
            new Signature(".pdf", "Adobe Acrobat Document", "application/pdf", new GeneralMatcher(new List<(Int32 Offset, Byte?[] MagicNumber)>()
            {
                (0, new Byte?[] { 0x25, 0x50, 0x44, 0x46 })
            })),
            new Signature(".zip", "PKZIP Compressed Archive", "application/x-zip-compressed", new GeneralMatcher(new List<(Int32 Offset, Byte?[] MagicNumber)>()
            {
                (0, new Byte?[] { 0x50, 0x4B, 0x03, 0x04 })
            })),
            new Signature(".rar", "WinRAR Compressed Archive", String.Empty, new GeneralMatcher(new List<(Int32 Offset, Byte?[] MagicNumber)>()
            {
                (0, new Byte?[] { 0x52, 0x61, 0x72, 0x21, 0x1A, 0x07 })
            })),
            new Signature(".doc", "Microsoft Word 97 - 2003 Document", "application/msword", new GeneralMatcher(new List<(Int32 Offset, Byte?[] MagicNumber)>()
            {
                (0, new Byte?[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 }),
                (512, new Byte?[] { 0xEC, 0xA5, 0xC1, 0x00 })
            })),
            new Signature(".xls", "Microsoft Excel 97-2003 Worksheet", "application/vnd.ms-excel", new GeneralMatcher(new List<(Int32 Offset, Byte?[] MagicNumber)>()
            {
                (0, new Byte?[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 }),
                (512, new Byte?[] { 0x09, 0x08, 0x10, 0x00, 0x00, 0x06, 0x05, 0x00 })
            })),
            new Signature(".ppt", "Microsoft PowerPoint 97-2003 Presentation", "application/vnd.ms-powerpoint", new GeneralMatcher(new List<(Int32 Offset, Byte?[] MagicNumber)>()
            {
                (0, new Byte?[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 }),
                (512, new Byte?[] { 0xFD, 0xFF, 0xFF, 0xFF, null, null, 0x00, 0x00 })
            })),
            new Signature(".docx", "Microsoft Word Document", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", new OfficeOpenXmlMatcher(new List<(Int32 Offset, Byte?[] MagicNumber)>()
            {
                (0, new Byte?[] { 0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x06, 0x00 })
            }, "/word/")),
            new Signature(".xlsx", "Microsoft Excel Worksheet", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", new OfficeOpenXmlMatcher(new List<(Int32 Offset, Byte?[] MagicNumber)>()
            {
                (0, new Byte?[] { 0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x06, 0x00 })
            }, "/xl/")),
            new Signature(".pptx", "Microsoft PowerPoint Presentation", "application/vnd.openxmlformats-officedocument.presentationml.presentation", new OfficeOpenXmlMatcher(new List<(Int32 Offset, Byte?[] MagicNumber)>()
            {
                (0, new Byte?[] { 0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x06, 0x00 })
            }, "/ppt/")),
            new Signature(".docx", "Microsoft Word Document", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", new OfficeOpenXmlMatcher(new List<(Int32 Offset, Byte?[] MagicNumber)>()
            {
                (0, new Byte?[] { 0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x00, 0x00 })
            }, "/word/")),
            new Signature(".xlsx", "Microsoft Excel Worksheet", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", new OfficeOpenXmlMatcher(new List<(Int32 Offset, Byte?[] MagicNumber)>()
            {
                (0, new Byte?[] { 0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x00, 0x00 })
            }, "/xl/")),
            new Signature(".pptx", "Microsoft PowerPoint Presentation", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", new OfficeOpenXmlMatcher(new List<(Int32 Offset, Byte?[] MagicNumber)>()
            {
                (0, new Byte?[] { 0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x00, 0x00 })
            }, "/ppt/"))
        };

        public List<Signature> Conjecture(String filePath)
        {
            using (Stream stream = File.OpenRead(filePath))
            {
                return Conjecture(stream);
            }
        }

        public List<Signature> Conjecture(Stream stream)
        {
            return KnownSignature.Where(x => x.IsMatch(stream)).OrderByDescending(x => x.Accuracy).ToList();
        }

        public Boolean IsMatch(String filePath)
        {
            using (Stream stream = File.OpenRead(filePath))
            {
                return IsMatch(stream, Path.GetExtension(filePath));
            }
        }

        public Boolean IsMatch(Stream stream, String extension)
        {
            return Conjecture(stream).Any(x => x.Extension.ToLower() == extension.ToLower());
        }
    }
}
