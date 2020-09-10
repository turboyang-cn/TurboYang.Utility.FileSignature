using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using TurboYang.Utility.FileSignature.Matchers;
using TurboYang.Utility.FileSignature.Signatures;

namespace TurboYang.Utility.FileSignature
{
    public class FileSignatureParser
    {
        public FileSignatureParser()
        {
            RegisterSignature(Assembly.GetExecutingAssembly());
        }

        private List<Signature> KnownSignature { get; } = new List<Signature>();

        public void RegisterSignature(Signature signature)
        {
            KnownSignature.Add(signature);
        }

        public void RegisterSignature(Assembly assembly)
        {
            KnownSignature.AddRange(assembly.GetTypes().Where(x => x.IsSubclassOf(typeof(Signature))).Select(x => Activator.CreateInstance(x) as Signature));
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
