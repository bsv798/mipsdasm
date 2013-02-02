using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsDasm.ps1
{
    public class Ps1Cop2dRegiserSet : RegisterSet
    {
        public Ps1Cop2dRegiserSet()
        {
            arr = new Register[32];
            arr[0] = new R00vxy0();
            arr[1] = new R01vz0();
            arr[2] = new R02vxy1();
            arr[3] = new R03vz1();
            arr[4] = new R04vx2();
            arr[5] = new R05vz2();
            arr[6] = new R06rgb();
            arr[7] = new R07otz();
            arr[8] = new R08ir0();
            arr[9] = new R09ir1();
            arr[10] = new R10ir2();
            arr[11] = new R11ir3();
            arr[12] = new R12sxy0();
            arr[13] = new R13sxy1();
            arr[14] = new R14sxy2();
            arr[15] = new R15sxyp();
            arr[16] = new R16sz0();
            arr[17] = new R17sz1();
            arr[18] = new R18sz2();
            arr[19] = new R19sz3();
            arr[20] = new R20rgb0();
            arr[21] = new R21rgb1();
            arr[22] = new R22rgb2();
            arr[23] = new R23res1();
            arr[24] = new R24mac0();
            arr[25] = new R25mac1();
            arr[26] = new R26mac2();
            arr[27] = new R27mac3();
            arr[28] = new R28irgb();
            arr[29] = new R29orgb();
            arr[30] = new R30lzcs();
            arr[31] = new R31lzcr();
        }
    }
}
