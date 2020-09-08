using System;
using System.IO;

namespace TurboYang.Utility.FileSignature.Matchers
{
    public abstract class Matcher
    {
        public abstract Int32 Accuracy { get; }
        public abstract Boolean IsMatch(Stream stream);
    }
}
