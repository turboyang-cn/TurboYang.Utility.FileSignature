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
``` csharp
FileSignatureParser parser = new FileSignatureParser();
List<Signature> signatures = parser.Detect("Your file path");
Signature accuratelySignature = signatures.FirstOrDefault();

String name = accuratelySignature.Name;             // Microsoft Word Document
String extension = accuratelySignature.Extension;   // .docx
String mediaType = accuratelySignature.MediaType;   // application/vnd.openxmlformats-officedocument.wordprocessingml.document
```
