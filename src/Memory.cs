using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using sio = System.IO;

namespace mipsDasm
{
    public abstract class Memory
    {
        private sio.MemoryStream stream;
        private sio.BinaryReader reader;
        private sio.BinaryWriter writer;

        public Memory(int size)
        {
            stream = new sio.MemoryStream(new byte[size], true);
            reader = new sio.BinaryReader(stream);
            writer = new sio.BinaryWriter(stream);
        }

        public void LoadFile(int memOffset, string fileName, int fileOffset, int size)
        {
            sio.FileStream fs = new sio.FileStream(fileName, sio.FileMode.Open, sio.FileAccess.Read);
            try
            {
                byte[] buf = new byte[size];
                fs.Read(buf, 0, size);
                writer.Write(buf);
            }
            finally
            {
                fs.Close();
            }
        }

        public int GetSize()
        {
            return stream.Capacity;
        }

        public int ReadOpcode(int pc)
        {
            return ReadWord(pc);
        }

        public int ReadWord(int addr)
        {
            stream.Position = addr;
            return reader.ReadInt32();
        }
    }
}
