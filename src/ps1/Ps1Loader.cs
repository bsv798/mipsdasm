using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using sio = System.IO;

namespace mipsDasm.ps1
{
    public class Ps1Loader
    {
        private int startPc;
        private Ps1Memory mem;
        public RawData[] data;
        private Ps1InstructionSet insSet;

        public static Ps1Loader FromPs1Executable(string fileName)
        {
            byte[] ps1ExeMagic = new byte[] { 0x50, 0x53, 0x2D, 0x58, 0x20, 0x45, 0x58, 0x45, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            sio.FileStream stream = new sio.FileStream(fileName, sio.FileMode.Open, sio.FileAccess.Read);
            sio.BinaryReader reader = new sio.BinaryReader(stream);

            try
            {
                byte[] buf = reader.ReadBytes(ps1ExeMagic.Length);
                for (int i = 0; i < ps1ExeMagic.Length; i++)
                {
                    if (buf[i] != ps1ExeMagic[i])
                        throw new FormatException("Wrong PS1 executable.");
                }

                int startPc = reader.ReadInt32().maskAddr();
                stream.Position += 4;
                int memOffset = reader.ReadInt32().maskAddr();
                int size = reader.ReadInt32();

                return new Ps1Loader(fileName, 0x800, memOffset, size, startPc);
            }
            finally
            {
                reader.Close();
                stream.Close();
            }
        }

        public Ps1Loader(string fileName, int fileOffset, int memOffset, int size, int startPc)
        {
            mem = new Ps1Memory();
            mem.LoadFile(memOffset, fileName, fileOffset, size);

            this.startPc = startPc;

            data = new RawData[mem.GetSize() / Instruction.size];

            insSet = new Ps1InstructionSet();
        }

        public void Analyze()
        {
            Analyze(startPc);
        }

        private void Analyze(int pc)
        {
            while (true)
            {
                Instruction ins = insSet.getInstruction(mem.ReadOpcode(pc));
                data[pc / Instruction.size] = ins;
                pc += 4;

                if ((ins is JrInstruction) && (((JrInstruction)ins).rs is R31ra))
                    break;
            }
        }
    }
}

