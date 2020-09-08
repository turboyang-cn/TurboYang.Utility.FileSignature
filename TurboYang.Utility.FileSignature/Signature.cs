using System;
using System.IO;
using TurboYang.Utility.FileSignature.Matchers;

namespace TurboYang.Utility.FileSignature
{
    public class Signature
    {
        public String Extension { get; }

        public String Name { get; }

        public String MediaType { get; }

        public Int32 Accuracy
        {
            get
            {
                return Matcher?.Accuracy ?? 0;
            }
        }

        private Matcher Matcher { get; }

        public Signature(String extension, String name, String mediaType, Matcher matcher)
        {
            Extension = extension;
            Name = name;
            MediaType = mediaType;
            Matcher = matcher;
        }

        public Boolean IsMatch(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);

            return Matcher == null || Matcher.IsMatch(stream);
        }
    }
}
