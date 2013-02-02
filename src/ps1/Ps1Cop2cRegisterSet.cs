using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsDasm.ps1
{
    public class Ps1Cop2cRegiserSet : RegisterSet
    {
        public Ps1Cop2cRegiserSet()
        {
            arr = new Register[32];
            arr[0] = new R00r11r12();
            arr[1] = new R01r13r21();
            arr[2] = new R02r22r23();
            arr[3] = new R03r31r32();
            arr[4] = new R04r33();
            arr[5] = new R05trx();
            arr[6] = new R06try();
            arr[7] = new R07trz();
            arr[8] = new R08l11l12();
            arr[9] = new R09l13l21();
            arr[10] = new R10l22l23();
            arr[11] = new R11l31l32();
            arr[12] = new R12l33();
            arr[13] = new R13rbk();
            arr[14] = new R14bbk();
            arr[15] = new R15gbk();
            arr[16] = new R16lr1lr2();
            arr[17] = new R17lr3lg1();
            arr[18] = new R18lg2lg3();
            arr[19] = new R19lb1lb2();
            arr[20] = new R20lb3();
            arr[21] = new R21rfc();
            arr[22] = new R22gfc();
            arr[23] = new R23bfc();
            arr[24] = new R24ofx();
            arr[25] = new R25ofy();
            arr[26] = new R26h();
            arr[27] = new R27dqa();
            arr[28] = new R28dqb();
            arr[29] = new R29zsf3();
            arr[30] = new R30zsf4();
            arr[31] = new R31flag();
        }
    }
}
