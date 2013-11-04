using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsDasm
{
    public static class Extension
    {
        public static int getIntFromBits(this int val, int startBit, int bitCount)
        {
            return (val << (32 - (startBit + bitCount))) >> (32 - bitCount);
        }

        public static int getUIntFromBits(this int val, int startBit, int bitCount)
        {
            return (val >> startBit) & ((1 << bitCount) - 1);
        }

        public static void assertEquals(this int actual, int expected)
        {
            if (actual != expected)
                throw new ArgumentException(string.Format("Assert equals failed: {0} != {1}.", actual, expected));
        }

        public static void assertEqualsZero(this int actual)
        {
            assertEquals(actual, 0);
        }

        public static int maskAddr(this int val)
        {
            return val & 0x7fffffff;
        }
    }
}
