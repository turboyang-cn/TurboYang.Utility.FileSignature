using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TurboYang.Utility.FileSignature.Matchers
{
    public class GeneralMatcher : Matcher
    {
        public override Int32 Accuracy 
        { 
            get 
            { 
                return MagicNumberList.Sum(x => x.MagicNumber.Count()); 
            } 
        }

        public List<(Int32 Offset, Byte?[] MagicNumber)> MagicNumberList { get; }

        public GeneralMatcher(List<(Int32 Offset, Byte?[] MagicNumber)> magicNumberList)
        {
            MagicNumberList = magicNumberList;
        }

        public override Boolean IsMatch(Stream stream)
        {
            return MagicNumberList.All(x => CheckMatch(stream, x.Offset, x.MagicNumber));
        }

        protected Boolean CheckMatch(Stream stream, Int32 offset, Byte?[] magicNumber)
        {
            try
            {
                stream.Seek(offset, SeekOrigin.Begin);

                Byte[] buffer = new Byte[magicNumber.Length];

                stream.Read(buffer, 0, magicNumber.Length);

                for (Int32 i = 0; i < buffer.Length; i++)
                {
                    if (magicNumber[i] == null)
                    {
                        continue;
                    }
                    else if (magicNumber[i] != buffer[i])
                    {
                        return false;
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
