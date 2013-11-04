using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsDasm
{
    public class Resource : RawData
    {
        public readonly int offset;

        public Resource(int offset, int size)
            : base(size)
        {
            this.offset = offset;
        }
    }
}
