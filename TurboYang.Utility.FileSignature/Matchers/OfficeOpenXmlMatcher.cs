using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.IO.Compression;
using System.Xml;

namespace TurboYang.Utility.FileType.Matchers
{
    public class OfficeOpenXmlMatcher : GeneralMatcher
    {
        public override Int32 Accuracy
        {
            get
            {
                return base.Accuracy + 1;
            }
        }

        public String PartName { get; }

        public OfficeOpenXmlMatcher(List<(Int32 Offser, Byte?[] MagicNumber)> magicNumberList, String partName)
            : base(magicNumberList)
        {
            PartName = partName;
        }

        public override Boolean IsMatch(Stream stream)
        {
            if (!base.IsMatch(stream))
            {
                return false;
            }

            try
            {
                using (ZipArchive archive = new ZipArchive(stream, ZipArchiveMode.Read, true))
                {
                    ZipArchiveEntry contentTypesEntry = archive.GetEntry("[Content_Types].xml");

                    if (contentTypesEntry == null)
                    {
                        return false;
                    }

                    using (Stream contentTypesStream = contentTypesEntry.Open())
                    {
                        XmlDocument xmlDocument = new XmlDocument();
                        xmlDocument.Load(contentTypesStream);

                        XmlNodeList nodeList = null;

                        if (xmlDocument.DocumentElement.Attributes["xmlns"] != null)
                        {
                            String xmlns = xmlDocument.DocumentElement.Attributes["xmlns"].Value;

                            XmlNamespaceManager namespaceManager = new XmlNamespaceManager(xmlDocument.NameTable);

                            namespaceManager.AddNamespace("ns", xmlns);

                            nodeList = xmlDocument.SelectNodes("/ns:Types/ns:Override", namespaceManager);
                        }
                        else
                        {
                            nodeList = xmlDocument.SelectNodes("Types/Override");
                        }

                        if (nodeList != null)
                        {
                            foreach (XmlNode node in nodeList)
                            {
                                if (node.Attributes["PartName"] != null)
                                {
                                    if (node.Attributes["PartName"].Value.StartsWith(PartName))
                                    {
                                        return true;
                                    }
                                    else
                                    {
                                        continue;
                                    }
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            return false;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
