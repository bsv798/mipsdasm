using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsDasm.ps1
{
    public class Ps1GprRegiserSet : RegisterSet
    {
        public Ps1GprRegiserSet()
        {
            arr = new Register[32];
            arr[0] = new R00zr();
            arr[1] = new R01at();
            arr[2] = new R02v0();
            arr[3] = new R03v1();
            arr[4] = new R04a0();
            arr[5] = new R05a1();
            arr[6] = new R06a2();
            arr[7] = new R07a3();
            arr[8] = new R08t0();
            arr[9] = new R09t1();
            arr[10] = new R10t2();
            arr[11] = new R11t3();
            arr[12] = new R12t4();
            arr[13] = new R13t5();
            arr[14] = new R14t6();
            arr[15] = new R15t7();
            arr[16] = new R16s0();
            arr[17] = new R17s1();
            arr[18] = new R18s2();
            arr[19] = new R19s3();
            arr[20] = new R20s4();
            arr[21] = new R21s5();
            arr[22] = new R22s6();
            arr[23] = new R23s7();
            arr[24] = new R24t8();
            arr[25] = new R25t9();
            arr[26] = new R26k0();
            arr[27] = new R27k1();
            arr[28] = new R28gp();
            arr[29] = new R29sp();
            arr[30] = new R30fp();
            arr[31] = new R31ra();
        }
    }
}
