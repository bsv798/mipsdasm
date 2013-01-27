using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsDasm
{
    public abstract class InstructionSet
    {
        protected RegisterSet regSet;

        public InstructionSet(RegisterSet regSet)
        {
            this.regSet = regSet;
        }

        public abstract Instruction getInstruction(int binary);
    }
}
