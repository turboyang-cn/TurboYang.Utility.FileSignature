using System;
using System.IO;
using TurboYang.Utility.FileType.Matchers;

namespace TurboYang.Utility.FileType
{
    public class FileType
    {
        public String Extension { get; }

        public String Name { get; }

        public Int32 Accuracy
        {
            get
            {
                return Matcher?.Accuracy ?? 0;
            }
        }

        private Matcher Matcher { get; }

        public FileType(String extension, String name, Matcher matcher)
        {
            Extension = extension;
            Name = name;
            Matcher = matcher;
        }

        public Boolean IsMatch(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);

            return Matcher == null || Matcher.IsMatch(stream);
        }
    }
}
