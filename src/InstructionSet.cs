using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsDasm
{
    public abstract class InstructionSet
    {
        protected RegisterSet gprRs;

        public InstructionSet(RegisterSet gprRs)
        {
            this.gprRs = gprRs;
        }

        public abstract Instruction getInstruction(int binary);
    }
}
