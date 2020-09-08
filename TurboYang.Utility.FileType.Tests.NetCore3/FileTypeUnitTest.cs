using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TurboYang.Utility.FileType.Tests.NetCore3
{
    [TestClass]
    public class FileTypeUnitTest
    {
        [TestMethod]
        public void TestMethod()
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
