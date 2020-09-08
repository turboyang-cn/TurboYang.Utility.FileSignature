using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TurboYang.Utility.FileSignature.Tests.NetCore3
{
    [TestClass]
    public class FileSignatureUnitTest
    {
        [TestMethod]
        public void TestMethod()
        {
            FileSignatureParser parser = new FileSignatureParser();

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
