using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsDasm
{
    public abstract class InstructionSet
    {
        public InstructionSet()
        {

        }

        public abstract Instruction getInstruction(int binary);
    }
}
