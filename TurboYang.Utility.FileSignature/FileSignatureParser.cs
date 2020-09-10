using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using TurboYang.Utility.FileSignature.Matchers;
using TurboYang.Utility.FileSignature.Signatures;

namespace TurboYang.Utility.FileSignature
{
    public class FileSignatureParser
    {
        public FileSignatureParser()
        {
            KnownSignature = GetType().Assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(Signature))).Select(x => Activator.CreateInstance(x) as Signature).ToList();
        }

        private List<Signature> KnownSignature { get; }

        public void RegisterSignature(Signature signature)
        {
            KnownSignature.Add(signature);
        }

        public ReadOnlyCollection<Signature> GetKnownSignature()
        {
            return KnownSignature.AsReadOnly();
        }

        public List<Signature> Detect(String filePath)
        {
            using (Stream stream = File.OpenRead(filePath))
            {
                return Detect(stream);
            }
        }

        public List<Signature> Detect(Stream stream)
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
            return Detect(stream).Any(x => x.Extension.ToLower() == extension.ToLower());
        }
    }
}
