using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsDasm.ps1
{
	public class Ps1Cop0cRegiserSet : RegisterSet
	{
		public Ps1Cop0cRegiserSet ()
		{
            arr = new Register[16];
            arr[0] = new R00indx();
            arr[1] = new R01rand();
            arr[2] = new R02tlbl();
            arr[3] = new R03bpc();
            arr[4] = new R04ctxt();
            arr[5] = new R05bda();
            arr[6] = new R06pidmask();
            arr[7] = new R07dcic();
            arr[8] = new R08badv();
            arr[9] = new R09bdam();
            arr[10] = new R10tlbh();
            arr[11] = new R11bpcm();
            arr[12] = new R12sr();
            arr[13] = new R13cause();
            arr[14] = new R14epc();
            arr[15] = new R15prid();
		}
	}
}

