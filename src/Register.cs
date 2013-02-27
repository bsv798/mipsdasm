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


    public sealed class R00r11r12 : Register
    {
        public R00r11r12()
            : base("r0", "r11r12")
        {

        }
    }

    public sealed class R01r13r21 : Register
    {
        public R01r13r21()
            : base("r1", "r13r21")
        {

        }
    }

    public sealed class R02r22r23 : Register
    {
        public R02r22r23()
            : base("r2", "r22r23")
        {

        }
    }

    public sealed class R03r31r32 : Register
    {
        public R03r31r32()
            : base("r3", "r31r32")
        {

        }
    }

    public sealed class R04r33 : Register
    {
        public R04r33()
            : base("r4", "r33")
        {

        }
    }

    public sealed class R05trx : Register
    {
        public R05trx()
            : base("r5", "trx")
        {

        }
    }

    public sealed class R06try : Register
    {
        public R06try()
            : base("r6", "try")
        {

        }
    }

    public sealed class R07trz : Register
    {
        public R07trz()
            : base("r7", "trz")
        {

        }
    }

    public sealed class R08l11l12 : Register
    {
        public R08l11l12()
            : base("r8", "l11l12")
        {

        }
    }

    public sealed class R09l13l21 : Register
    {
        public R09l13l21()
            : base("r9", "l13l21")
        {

        }
    }

    public sealed class R10l22l23 : Register
    {
        public R10l22l23()
            : base("r10", "l22l23")
        {

        }
    }

    public sealed class R11l31l32 : Register
    {
        public R11l31l32()
            : base("r11", "l31l32")
        {

        }
    }

    public sealed class R12l33 : Register
    {
        public R12l33()
            : base("r12", "l33")
        {

        }
    }

    public sealed class R13rbk : Register
    {
        public R13rbk()
            : base("r13", "rbk")
        {

        }
    }

    public sealed class R14bbk : Register
    {
        public R14bbk()
            : base("r14", "bbk")
        {

        }
    }

    public sealed class R15gbk : Register
    {
        public R15gbk()
            : base("r15", "gbk")
        {

        }
    }

    public sealed class R16lr1lr2 : Register
    {
        public R16lr1lr2()
            : base("r16", "lr1lr2")
        {

        }
    }

    public sealed class R17lr3lg1 : Register
    {
        public R17lr3lg1()
            : base("r17", "lr3lg3")
        {

        }
    }

    public sealed class R18lg2lg3 : Register
    {
        public R18lg2lg3()
            : base("r18", "lg2lg3")
        {

        }
    }

    public sealed class R19lb1lb2 : Register
    {
        public R19lb1lb2()
            : base("r19", "lb1lb2")
        {

        }
    }

    public sealed class R20lb3 : Register
    {
        public R20lb3()
            : base("r20", "lb3")
        {

        }
    }

    public sealed class R21rfc : Register
    {
        public R21rfc()
            : base("r21", "rfc")
        {

        }
    }

    public sealed class R22gfc : Register
    {
        public R22gfc()
            : base("r22", "gfc")
        {

        }
    }

    public sealed class R23bfc : Register
    {
        public R23bfc()
            : base("r23", "bfc")
        {

        }
    }

    public sealed class R24ofx : Register
    {
        public R24ofx()
            : base("r24", "ofx")
        {

        }
    }

    public sealed class R25ofy : Register
    {
        public R25ofy()
            : base("r25", "ofy")
        {

        }
    }

    public sealed class R26h : Register
    {
        public R26h()
            : base("r26", "h")
        {

        }
    }

    public sealed class R27dqa : Register
    {
        public R27dqa()
            : base("r27", "dqa")
        {

        }
    }

    public sealed class R28dqb : Register
    {
        public R28dqb()
            : base("r28", "dqb")
        {

        }
    }

    public sealed class R29zsf3 : Register
    {
        public R29zsf3()
            : base("r29", "zsf3")
        {

        }
    }

    public sealed class R30zsf4 : Register
    {
        public R30zsf4()
            : base("r30", "zsf4")
        {

        }
    }

    public sealed class R31flag : Register
    {
        public R31flag()
            : base("r31", "flag")
        {

        }
    }


    public sealed class R00vxy0 : Register
    {
        public R00vxy0()
            : base("r0", "vxy0")
        {

        }
    }

    public sealed class R01vz0 : Register
    {
        public R01vz0()
            : base("r1", "vz0")
        {

        }
    }

    public sealed class R02vxy1 : Register
    {
        public R02vxy1()
            : base("r2", "vxy1")
        {

        }
    }

    public sealed class R03vz1 : Register
    {
        public R03vz1()
            : base("r3", "vz1")
        {

        }
    }

    public sealed class R04vx2 : Register
    {
        public R04vx2()
            : base("r4", "vx2")
        {

        }
    }

    public sealed class R05vz2 : Register
    {
        public R05vz2()
            : base("r5", "vz2")
        {

        }
    }

    public sealed class R06rgb : Register
    {
        public R06rgb()
            : base("r6", "rgb")
        {

        }
    }

    public sealed class R07otz : Register
    {
        public R07otz()
            : base("r7", "otz")
        {

        }
    }

    public sealed class R08ir0 : Register
    {
        public R08ir0()
            : base("r8", "ir0")
        {

        }
    }

    public sealed class R09ir1 : Register
    {
        public R09ir1()
            : base("r9", "ir1")
        {

        }
    }

    public sealed class R10ir2 : Register
    {
        public R10ir2()
            : base("r10", "ir2")
        {

        }
    }

    public sealed class R11ir3 : Register
    {
        public R11ir3()
            : base("r11", "ir3")
        {

        }
    }

    public sealed class R12sxy0 : Register
    {
        public R12sxy0()
            : base("r12", "sxy0")
        {

        }
    }

    public sealed class R13sxy1 : Register
    {
        public R13sxy1()
            : base("r13", "sxy1")
        {

        }
    }

    public sealed class R14sxy2 : Register
    {
        public R14sxy2()
            : base("r14", "sxy2")
        {

        }
    }

    public sealed class R15sxyp : Register
    {
        public R15sxyp()
            : base("r15", "sxyp")
        {

        }
    }

    public sealed class R16sz0 : Register
    {
        public R16sz0()
            : base("r16", "sz0")
        {

        }
    }

    public sealed class R17sz1 : Register
    {
        public R17sz1()
            : base("r17", "sz1")
        {

        }
    }

    public sealed class R18sz2 : Register
    {
        public R18sz2()
            : base("r18", "sz2")
        {

        }
    }

    public sealed class R19sz3 : Register
    {
        public R19sz3()
            : base("r19", "sz3")
        {

        }
    }

    public sealed class R20rgb0 : Register
    {
        public R20rgb0()
            : base("r20", "rgb0")
        {

        }
    }

    public sealed class R21rgb1 : Register
    {
        public R21rgb1()
            : base("r21", "rgb1")
        {

        }
    }

    public sealed class R22rgb2 : Register
    {
        public R22rgb2()
            : base("r22", "rgb2")
        {

        }
    }

    public sealed class R23res1 : Register
    {
        public R23res1()
            : base("r23", "res1")
        {

        }
    }

    public sealed class R24mac0 : Register
    {
        public R24mac0()
            : base("r24", "mac0")
        {

        }
    }

    public sealed class R25mac1 : Register
    {
        public R25mac1()
            : base("r25", "mac1")
        {

        }
    }

    public sealed class R26mac2 : Register
    {
        public R26mac2()
            : base("r26", "mac2")
        {

        }
    }

    public sealed class R27mac3 : Register
    {
        public R27mac3()
            : base("r27", "mac3")
        {

        }
    }

    public sealed class R28irgb : Register
    {
        public R28irgb()
            : base("r28", "irgb")
        {

        }
    }

    public sealed class R29orgb : Register
    {
        public R29orgb()
            : base("r29", "orgb")
        {

        }
    }

    public sealed class R30lzcs : Register
    {
        public R30lzcs()
            : base("r30", "lzcs")
        {

        }
    }

    public sealed class R31lzcr : Register
    {
        public R31lzcr()
            : base("r31", "lzcr")
        {

        }
    }

    public sealed class R00indx : Register
    {
        public R00indx ()
            :base("r0", "indx")
        {
            
        }
    }

    public sealed class R01rand : Register
    {
        public R01rand ()
            :base("r1", "rand")
        {
            
        }
    }

    public sealed class R02tlbl : Register
    {
        public R02tlbl ()
            :base("r2", "tlbl")
        {
            
        }
    }

    public sealed class R03bpc : Register
    {
        public R03bpc ()
            :base("r3", "bpc")
        {
            
        }
    }

    public sealed class R04ctxt : Register
    {
        public R04ctxt ()
            :base("r4", "ctxt")
        {
            
        }
    }

    public sealed class R05bda : Register
    {
        public R05bda ()
            :base("r5", "bda")
        {
            
        }
    }

    public sealed class R06pidmask : Register
    {
        public R06pidmask ()
            :base("r6", "pidmask")
        {
            
        }
    }

    public sealed class R07dcic : Register
    {
        public R07dcic ()
            :base("r7", "dcic")
        {
            
        }
    }

    public sealed class R08badv : Register
    {
        public R08badv ()
            :base("r8", "badv")
        {
            
        }
    }

    public sealed class R09bdam : Register
    {
        public R09bdam ()
            :base("r9", "bdam")
        {
            
        }
    }

    public sealed class R10tlbh : Register
    {
        public R10tlbh ()
            :base("r10", "tlbh")
        {
            
        }
    }

    public sealed class R11bpcm : Register
    {
        public R11bpcm ()
            :base("r11", "bpcm")
        {
            
        }
    }

    public sealed class R12sr : Register
    {
        public R12sr ()
            :base("r12", "sr")
        {
            
        }
    }

    public sealed class R13cause : Register
    {
        public R13cause ()
            :base("r13", "cause")
        {
            
        }
    }

    public sealed class R14epc : Register
    {
        public R14epc ()
            :base("r14", "epc")
        {
            
        }
    }

    public sealed class R15prid : Register
    {
        public R15prid ()
            :base("r15", "prid")
        {
            
        }
    }
}
