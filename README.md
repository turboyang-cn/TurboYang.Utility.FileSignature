# TurboYang.Utility.FileSignature
[![Build Status](https://vsrm.dev.azure.com/TurboYang-CN/_apis/public/Release/badge/d54d573a-c123-4212-9f52-18af1055650b/1/1)](https://vsrm.dev.azure.com/TurboYang-CN/_apis/public/Release/badge/d54d573a-c123-4212-9f52-18af1055650b/1/1) [![NuGet version (TurboYang.Utility.FileSignature)](https://img.shields.io/nuget/v/TurboYang.Utility.FileSignature.svg?style=flat)](https://www.nuget.org/packages/TurboYang.Utility.FileSignature/) [![MIT License](https://img.shields.io/badge/license-MIT-green.svg)](https://github.com/turboyang-cn/TurboYang.Utility.FileSignature/blob/master/LICENSE)

The library for detecting the type of file based on file header signature (magic number). Implementation for .NET Standard 2.0.

## Installation
Install with Package Manager:
```
Install-Package TurboYang.Utility.FileSignature
```

## Usage: Detect file type
You can directly use the following code to detect the file type.
``` CSharp
FileSignatureParser parser = new FileSignatureParser();
List<Signature> signatures = parser.Detect("Your file path");
Signature accuratelySignature = signatures.FirstOrDefault();

String name = accuratelySignature.Name;             // Microsoft Word Document
String extension = accuratelySignature.Extension;   // .docx
String mediaType = accuratelySignature.MediaType;   // application/vnd.openxmlformats-officedocument.wordprocessingml.document
```
The `Detect` method returns a list of all possible file types, sorted according to the accuracy of the match. The first record in the list is the most accurate match.

## Usage: Check file extension
You can use the following code to directly check that the file extension matches the header signature.
``` CSharp
FileSignatureParser parser = new FileSignatureParser();

Boolean isMatch = parser.IsMatch("Your file path");
```

## Usage: Register new file type
If you have a new file type, you can register with the following code.
Suppose there are file types `Microsoft SQL Server 2000 Database`, its extension is `.mdf`, magic number is `01 0F 00 00`.
``` CSharp
FileSignatureParser parser = new FileSignatureParser();

parser.RegisterSignature(new Signature(".mdf", "Microsoft SQL Server 2000 Database", String.Empty, new GeneralMatcher(new List<(Int32 Offset, Byte?[] MagicNumber)>()
{
    (0, new Byte?[] { 0x01, 0x0F, 0x00, 0x00 })
})));
```

## List of known file types
| Name | Media Type | Extension |
| ---- | ---------- | --------- |
| Bitmap Image | image/bmp | .bmp |
| GIF Image | image/gif | .gif |
| JPEG Image | image/jpeg | .jpg |
| PNG Image | image/png | .png |
| Tagged Image File Format File | image/tiff | .tif |
| Windows Media Audio/Video File | video/x-ms-wmv | .wmv |
| Windows/DOS Executable File | application/x-msdownload | .exe |
| PKZIP Compressed Archive | application/x-zip-compressed | .zip |
| WinRAR Compressed Archive |  | .rar |
| Microsoft Word 97 - 2003 Document | application/msword | .doc |
| Microsoft Excel 97-2003 Worksheet | application/vnd.ms-excel | .xls |
| Microsoft PowerPoint 97-2003 Presentation | application/vnd.ms-powerpoint | .ppt |
| Microsoft Word Document | application/vnd.openxmlformats-officedocument.wordprocessingml.document | .docx |
| Microsoft Excel Worksheet | application/vnd.openxmlformats-officedocument.spreadsheetml.sheet | .xlsx |
| Microsoft PowerPoint Presentation | application/vnd.openxmlformats-officedocument.presentationml.presentation | .pptx |
