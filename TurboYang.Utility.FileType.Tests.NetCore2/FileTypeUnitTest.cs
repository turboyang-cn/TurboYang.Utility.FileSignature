using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TurboYang.Utility.FileType.Tests.NetCore2
{
    [TestClass]
    public class FileTypeUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            FileTypeParser parser = new FileTypeParser();

            DirectoryInfo sampleDirectory = new DirectoryInfo($"{AppDomain.CurrentDomain.BaseDirectory}Samples");

            if (sampleDirectory.Exists)
            {
                foreach (FileInfo file in new DirectoryInfo($"{AppDomain.CurrentDomain.BaseDirectory}Samples").GetFiles())
                {
                    Assert.IsTrue(parser.IsMatch(file.FullName));
                }
            }
            else
            {
                Assert.IsTrue(false);
            }
        }
    }
}
