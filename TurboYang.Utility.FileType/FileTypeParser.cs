using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TurboYang.Utility.FileType.Matchers;

namespace TurboYang.Utility.FileType
{
    public class FileTypeParser
    {
        public List<FileType> KnownFileTypes { get; set; } = new List<FileType>()
        {
            new FileType(".bmp", "Bitmap Image", new GeneralMatcher(new List<(Int32 Offset, Byte?[] MagicNumber)>()
            {
                (0, new Byte?[] { 0x42, 0x4D })
            })),
            new FileType(".gif", "GIF Image", new GeneralMatcher(new List<(Int32 Offset, Byte?[] MagicNumber)>()
            {
                (0, new Byte?[] { 0x47, 0x49, 0x46, 0x38, 0x37, 0x61 })
            })),
            new FileType(".gif", "GIF Image", new GeneralMatcher(new List<(Int32 Offset, Byte?[] MagicNumber)>()
            {
                (0, new Byte?[] { 0x47, 0x49, 0x46, 0x38, 0x39, 0x61 })
            })),
            new FileType(".jpg", "JPEG Image", new GeneralMatcher(new List<(Int32 Offset, Byte?[] MagicNumber)>()
            {
                (0, new Byte?[] { 0xFF, 0xD8 })
            })),
            new FileType(".png", "PNG Image", new GeneralMatcher(new List<(Int32 Offset, Byte?[] MagicNumber)>()
            {
                (0, new Byte?[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A })
            })),
            new FileType(".wmv", "Windows Media Audio/Video File", new GeneralMatcher(new List<(Int32 Offset, Byte?[] MagicNumber)>()
            {
                (0, new Byte?[] { 0x30, 0x26, 0xB2, 0x75, 0x8E, 0x66, 0xCF, 0x11, 0xA6, 0xD9, 0x00, 0xAA, 0x00, 0x62, 0xCE, 0x6C })
            })),
            new FileType(".pdf", "Adobe Acrobat Document", new GeneralMatcher(new List<(Int32 Offset, Byte?[] MagicNumber)>()
            {
                (0, new Byte?[] { 0x25, 0x50, 0x44, 0x46 })
            })),
            new FileType(".zip", "PKZIP Compressed Archive", new GeneralMatcher(new List<(Int32 Offset, Byte?[] MagicNumber)>()
            {
                (0, new Byte?[] { 0x50, 0x4B, 0x03, 0x04 })
            })),
            new FileType(".rar", "WinRAR Compressed Archive", new GeneralMatcher(new List<(Int32 Offset, Byte?[] MagicNumber)>()
            {
                (0, new Byte?[] { 0x52, 0x61, 0x72, 0x21, 0x1A, 0x07 })
            })),

            new FileType(".doc", "Microsoft Word 97 - 2003 Document", new GeneralMatcher(new List<(Int32 Offset, Byte?[] MagicNumber)>()
            {
                (0, new Byte?[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 }),
                (512, new Byte?[] { 0xEC, 0xA5, 0xC1, 0x00 })
            })),
            new FileType(".xls", "Microsoft Excel 97-2003 Worksheet", new GeneralMatcher(new List<(Int32 Offset, Byte?[] MagicNumber)>()
            {
                (0, new Byte?[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 }),
                (512, new Byte?[] { 0x09, 0x08, 0x10, 0x00, 0x00, 0x06, 0x05, 0x00 })
            })),
            new FileType(".ppt", "Microsoft PowerPoint 97-2003 Presentation", new GeneralMatcher(new List<(Int32 Offset, Byte?[] MagicNumber)>()
            {
                (0, new Byte?[] { 0xD0, 0xCF, 0x11, 0xE0, 0xA1, 0xB1, 0x1A, 0xE1 }),
                (512, new Byte?[] { 0xFD, 0xFF, 0xFF, 0xFF, null, null, 0x00, 0x00 })
            })),
            new FileType(".docx", "Microsoft Word Document", new OfficeOpenXmlMatcher(new List<(Int32 Offset, Byte?[] MagicNumber)>()
            {
                (0, new Byte?[] { 0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x06, 0x00 })
            }, "/word/")),
            new FileType(".xlsx", "Microsoft Excel Worksheet", new OfficeOpenXmlMatcher(new List<(Int32 Offset, Byte?[] MagicNumber)>()
            {
                (0, new Byte?[] { 0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x06, 0x00 })
            }, "/xl/")),
            new FileType(".pptx", "Microsoft PowerPoint Presentation", new OfficeOpenXmlMatcher(new List<(Int32 Offset, Byte?[] MagicNumber)>()
            {
                (0, new Byte?[] { 0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x06, 0x00 })
            }, "/ppt/")),
            new FileType(".docx", "Microsoft Word Document", new OfficeOpenXmlMatcher(new List<(Int32 Offset, Byte?[] MagicNumber)>()
            {
                (0, new Byte?[] { 0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x00, 0x00 })
            }, "/word/")),
            new FileType(".xlsx", "Microsoft Excel Worksheet", new OfficeOpenXmlMatcher(new List<(Int32 Offset, Byte?[] MagicNumber)>()
            {
                (0, new Byte?[] { 0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x00, 0x00 })
            }, "/xl/")),
            new FileType(".pptx", "Microsoft PowerPoint Presentation", new OfficeOpenXmlMatcher(new List<(Int32 Offset, Byte?[] MagicNumber)>()
            {
                (0, new Byte?[] { 0x50, 0x4B, 0x03, 0x04, 0x14, 0x00, 0x00, 0x00 })
            }, "/ppt/"))
        };

        public List<FileType> Conjecture(String filePath)
        {
            using (Stream stream = File.OpenRead(filePath))
            {
                return Conjecture(stream);
            }
        }

        public List<FileType> Conjecture(Stream stream)
        {
            return KnownFileTypes.Where(x => x.IsMatch(stream)).OrderByDescending(x => x.Accuracy).ToList();
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
            return Conjecture(stream).Any(x => x.Extension == extension);
        }
    }
}
