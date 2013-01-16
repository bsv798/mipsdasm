using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsDasm
{
    public abstract class Register
    {
        private static bool useNumericNames;
        private string symbolName;
        private string numericName;

        public static void setUseNemericNames(bool val)
        {
            useNumericNames = val;
        }

        public static bool getUseNumericNames()
        {
            return useNumericNames;
        }

        private Register()
        {

        }

        public Register(string numericName, string symbolName)
        {
            this.numericName = numericName;
            this.symbolName = symbolName;
        }

        public Register(string name)
            : this(name, name)
        {

        }

        public override string ToString()
        {
            return (useNumericNames) ? numericName : symbolName;
        }
    }

    public sealed class R00zr : Register
    {
        public R00zr()
            : base("r0", "zero")
        {

        }
    }

    public sealed class R01at : Register
    {
        public R01at()
            : base("r1", "at")
        {

        }
    }

    public sealed class R02v0 : Register
    {
        public R02v0()
            : base("r2", "v0")
        {

        }
    }

    public sealed class R03v1 : Register
    {
        public R03v1()
            : base("r3", "v1")
        {

        }
    }

    public sealed class R04a0 : Register
    {
        public R04a0()
            : base("r4", "a0")
        {

        }
    }

    public sealed class R05a1 : Register
    {
        public R05a1()
            : base("r5", "a1")
        {

        }
    }

    public sealed class R06a2 : Register
    {
        public R06a2()
            : base("r6", "a2")
        {

        }
    }

    public sealed class R07a3 : Register
    {
        public R07a3()
            : base("r7", "a3")
        {

        }
    }

    public sealed class R08t0 : Register
    {
        public R08t0()
            : base("r8", "t0")
        {

        }
    }

    public sealed class R09t1 : Register
    {
        public R09t1()
            : base("r9", "t1")
        {

        }
    }

    public sealed class R10t2 : Register
    {
        public R10t2()
            : base("r10", "t2")
        {

        }
    }

    public sealed class R11t3 : Register
    {
        public R11t3()
            : base("r11", "t3")
        {

        }
    }

    public sealed class R12t4 : Register
    {
        public R12t4()
            : base("r12", "t4")
        {

        }
    }

    public sealed class R13t5 : Register
    {
        public R13t5()
            : base("r13", "t5")
        {

        }
    }

    public sealed class R14t6 : Register
    {
        public R14t6()
            : base("r14", "t6")
        {

        }
    }

    public sealed class R15t7 : Register
    {
        public R15t7()
            : base("r15", "t7")
        {

        }
    }

    public sealed class R16s0 : Register
    {
        public R16s0()
            : base("r16", "s0")
        {

        }
    }

    public sealed class R17s1 : Register
    {
        public R17s1()
            : base("r17", "s1")
        {

        }
    }

    public sealed class R18s2 : Register
    {
        public R18s2()
            : base("r18", "s2")
        {

        }
    }

    public sealed class R19s3 : Register
    {
        public R19s3()
            : base("r19", "s3")
        {

        }
    }

    public sealed class R20s4 : Register
    {
        public R20s4()
            : base("r20", "s4")
        {

        }
    }

    public sealed class R21s5 : Register
    {
        public R21s5()
            : base("r21", "s5")
        {

        }
    }

    public sealed class R22s6 : Register
    {
        public R22s6()
            : base("r22", "s6")
        {

        }
    }

    public sealed class R23s7 : Register
    {
        public R23s7()
            : base("r23", "s7")
        {

        }
    }

    public sealed class R24t8 : Register
    {
        public R24t8()
            : base("r24", "t8")
        {

        }
    }

    public sealed class R25t9 : Register
    {
        public R25t9()
            : base("r25", "t9")
        {

        }
    }

    public sealed class R26k0 : Register
    {
        public R26k0()
            : base("r26", "k0")
        {

        }
    }

    public sealed class R27k1 : Register
    {
        public R27k1()
            : base("r27", "k1")
        {

        }
    }

    public sealed class R28gp : Register
    {
        public R28gp()
            : base("r28", "gp")
        {

        }
    }

    public sealed class R29sp : Register
    {
        public R29sp()
            : base("r29", "sp")
        {

        }
    }

    public sealed class R30fp : Register
    {
        public R30fp()
            : base("r30", "fp")
        {

        }
    }

    public sealed class R31ra : Register
    {
        public R31ra()
            : base("r31", "ra")
        {

        }
    }
}
