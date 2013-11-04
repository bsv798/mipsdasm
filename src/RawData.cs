using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsDasm
{
    public abstract class RawData
    {
        public readonly int size;

        public RawData(int size)
        {
            this.size = size;
        }
    }
}
