using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsDasm.ps1
{
    public class Ps1InstructionSet : InstructionSet
    {
        public Ps1InstructionSet(RegisterSet regSet)
            : base(regSet)
        {

        }

        public override Instruction getInstruction(int binary)
        {
            if (binary == 0)
            {
                return new NopInstruction();
            }
            else
            {
                switch (binary.getUIntFromBits(26, 6))
                {
                    case SpecialInstruction.opcode:
                        switch (binary.getUIntFromBits(0, 6))
                        {
                            case AddInstruction.opcode:
                                binary.getUIntFromBits(6, 5).assertEqualsZero();
                                return new AddInstruction(regSet.getRegister(binary.getUIntFromBits(11, 5)), regSet.getRegister(binary.getUIntFromBits(21, 5)), regSet.getRegister(binary.getUIntFromBits(16, 5)));
                            case AdduInstruction.opcode:
                                binary.getUIntFromBits(6, 5).assertEqualsZero();
                                return new AdduInstruction(regSet.getRegister(binary.getUIntFromBits(11, 5)), regSet.getRegister(binary.getUIntFromBits(21, 5)), regSet.getRegister(binary.getUIntFromBits(16, 5)));
                            case AndInstruction.opcode:
                                binary.getUIntFromBits(6, 5).assertEqualsZero();
                                return new AndInstruction(regSet.getRegister(binary.getUIntFromBits(11, 5)), regSet.getRegister(binary.getUIntFromBits(21, 5)), regSet.getRegister(binary.getUIntFromBits(16, 5)));
                            case BreakInstruction.opcode:
                                return new BreakInstruction(binary.getUIntFromBits(6, 20));
                            case DivInstruction.opcode:
                                binary.getUIntFromBits(6, 10).assertEqualsZero();
                                return new DivInstruction(regSet.getRegister(binary.getUIntFromBits(21, 5)), regSet.getRegister(binary.getUIntFromBits(16, 5)));
                            case DivuInstruction.opcode:
                                binary.getUIntFromBits(6, 10).assertEqualsZero();
                                return new DivuInstruction(regSet.getRegister(binary.getUIntFromBits(21, 5)), regSet.getRegister(binary.getUIntFromBits(16, 5)));
                            case JalrInstruction.opcode:
                                binary.getUIntFromBits(6, 10).assertEqualsZero();
                                return new JalrInstruction(regSet.getRegister(31), regSet.getRegister(binary.getUIntFromBits(21, 5)));
                            case JrInstruction.opcode:
                                binary.getUIntFromBits(6, 15).assertEqualsZero();
                                return new JrInstruction(regSet.getRegister(binary.getUIntFromBits(21, 5)));
                            case MfhiInstruction.opcode:
                                binary.getUIntFromBits(6, 5).assertEqualsZero();
                                binary.getUIntFromBits(16, 10).assertEqualsZero();
                                return new MfhiInstruction(regSet.getRegister(binary.getUIntFromBits(11, 5)));
                            case MfloInstruction.opcode:
                                binary.getUIntFromBits(6, 5).assertEqualsZero();
                                binary.getUIntFromBits(16, 10).assertEqualsZero();
                                return new MfloInstruction(regSet.getRegister(binary.getUIntFromBits(11, 5)));
                            case MthiInstruction.opcode:
                                binary.getUIntFromBits(6, 15).assertEqualsZero();
                                return new MthiInstruction(regSet.getRegister(binary.getUIntFromBits(21, 5)));
                            case MtloInstruction.opcode:
                                binary.getUIntFromBits(6, 15).assertEqualsZero();
                                return new MtloInstruction(regSet.getRegister(binary.getUIntFromBits(21, 5)));
                            case MultInstruction.opcode:
                                binary.getUIntFromBits(6, 10).assertEqualsZero();
                                return new MultInstruction(regSet.getRegister(binary.getUIntFromBits(21, 5)), regSet.getRegister(binary.getUIntFromBits(16, 5)));
                            case MultuInstruction.opcode:
                                binary.getUIntFromBits(6, 10).assertEqualsZero();
                                return new MultuInstruction(regSet.getRegister(binary.getUIntFromBits(21, 5)), regSet.getRegister(binary.getUIntFromBits(16, 5)));
                            case NorInstruction.opcode:
                                binary.getUIntFromBits(6, 5).assertEqualsZero();
                                return new NorInstruction(regSet.getRegister(binary.getUIntFromBits(11, 5)), regSet.getRegister(binary.getUIntFromBits(21, 5)), regSet.getRegister(binary.getUIntFromBits(16, 5)));
                            case OrInstruction.opcode:
                                binary.getUIntFromBits(6, 5).assertEqualsZero();
                                return new OrInstruction(regSet.getRegister(binary.getUIntFromBits(11, 5)), regSet.getRegister(binary.getUIntFromBits(21, 5)), regSet.getRegister(binary.getUIntFromBits(16, 5)));
                            case SllInstruction.opcode:
                                binary.getUIntFromBits(21, 5).assertEqualsZero();
                                return new SllInstruction(regSet.getRegister(binary.getUIntFromBits(11, 5)), regSet.getRegister(binary.getUIntFromBits(16, 5)), binary.getUIntFromBits(6, 5));
                            case SllvInstruction.opcode:
                                binary.getUIntFromBits(6, 5).assertEqualsZero();
                                return new SllvInstruction(regSet.getRegister(binary.getUIntFromBits(11, 5)), regSet.getRegister(binary.getUIntFromBits(16, 5)), regSet.getRegister(binary.getUIntFromBits(21, 5)));
                            case SltInstruction.opcode:
                                binary.getUIntFromBits(6, 5).assertEqualsZero();
                                return new SltInstruction(regSet.getRegister(binary.getUIntFromBits(11, 5)), regSet.getRegister(binary.getUIntFromBits(21, 5)), regSet.getRegister(binary.getUIntFromBits(16, 5)));
                            case SltuInstruction.opcode:
                                binary.getUIntFromBits(6, 5).assertEqualsZero();
                                return new SltuInstruction(regSet.getRegister(binary.getUIntFromBits(11, 5)), regSet.getRegister(binary.getUIntFromBits(21, 5)), regSet.getRegister(binary.getUIntFromBits(16, 5)));
                            case SraInstruction.opcode:
                                binary.getUIntFromBits(21, 5).assertEqualsZero();
                                return new SraInstruction(regSet.getRegister(binary.getUIntFromBits(11, 5)), regSet.getRegister(binary.getUIntFromBits(16, 5)), binary.getUIntFromBits(6, 5));
                            case SravInstruction.opcode:
                                binary.getUIntFromBits(6, 5).assertEqualsZero();
                                return new SravInstruction(regSet.getRegister(binary.getUIntFromBits(11, 5)), regSet.getRegister(binary.getUIntFromBits(16, 5)), regSet.getRegister(binary.getUIntFromBits(21, 5)));
                            case SrlInstruction.opcode:
                                binary.getUIntFromBits(21, 5).assertEqualsZero();
                                return new SrlInstruction(regSet.getRegister(binary.getUIntFromBits(11, 5)), regSet.getRegister(binary.getUIntFromBits(16, 5)), binary.getUIntFromBits(6, 5));
                            case SrlvInstruction.opcode:
                                binary.getUIntFromBits(6, 5).assertEqualsZero();
                                return new SrlvInstruction(regSet.getRegister(binary.getUIntFromBits(11, 5)), regSet.getRegister(binary.getUIntFromBits(16, 5)), regSet.getRegister(binary.getUIntFromBits(21, 5)));
                            case SubInstruction.opcode:
                                binary.getUIntFromBits(6, 5).assertEqualsZero();
                                return new SubInstruction(regSet.getRegister(binary.getUIntFromBits(11, 5)), regSet.getRegister(binary.getUIntFromBits(21, 5)), regSet.getRegister(binary.getUIntFromBits(16, 5)));
                            case SubuInstruction.opcode:
                                binary.getUIntFromBits(6, 5).assertEqualsZero();
                                return new SubuInstruction(regSet.getRegister(binary.getUIntFromBits(11, 5)), regSet.getRegister(binary.getUIntFromBits(21, 5)), regSet.getRegister(binary.getUIntFromBits(16, 5)));
                            case SyscallInstruction.opcode:
                                return new SyscallInstruction(binary.getUIntFromBits(6, 20));
                            case XorInstruction.opcode:
                                binary.getUIntFromBits(6, 5).assertEqualsZero();
                                return new XorInstruction(regSet.getRegister(binary.getUIntFromBits(11, 5)), regSet.getRegister(binary.getUIntFromBits(21, 5)), regSet.getRegister(binary.getUIntFromBits(16, 5)));
                            default:
                                throw new ArgumentException(string.Format("Unknown instruction: {0:x8}.", binary));
                        }
                    case RegimmInstruction.opcode:
                        switch (binary.getUIntFromBits(16, 5))
                        {
                            case BgezInstruction.opcode:
                                return new BgezInstruction(regSet.getRegister(binary.getUIntFromBits(21, 5)), binary.getIntFromBits(0, 16));
                            case BgezalInstruction.opcode:
                                return new BgezalInstruction(regSet.getRegister(binary.getUIntFromBits(21, 5)), binary.getIntFromBits(0, 16));
                            case BltzInstruction.opcode:
                                return new BltzInstruction(regSet.getRegister(binary.getUIntFromBits(21, 5)), binary.getIntFromBits(0, 16));
                            case BltzalInstruction.opcode:
                                return new BltzalInstruction(regSet.getRegister(binary.getUIntFromBits(21, 5)), binary.getIntFromBits(0, 16));
                            default:
                                throw new ArgumentException(string.Format("Unknown instruction: {0:x8}.", binary));
                        }
                    case AddiInstruction.opcode:
                        return new AddiInstruction(regSet.getRegister(binary.getUIntFromBits(16, 5)), regSet.getRegister(binary.getUIntFromBits(21, 5)), binary.getIntFromBits(0, 16));
                    case AddiuInstruction.opcode:
                        return new AddiuInstruction(regSet.getRegister(binary.getUIntFromBits(16, 5)), regSet.getRegister(binary.getUIntFromBits(21, 5)), binary.getIntFromBits(0, 16));
                    case AndiInstruction.opcode:
                        return new AndiInstruction(regSet.getRegister(binary.getUIntFromBits(16, 5)), regSet.getRegister(binary.getUIntFromBits(21, 5)), binary.getUIntFromBits(0, 16));
                    case BeqInstruction.opcode:
                        return new BeqInstruction(regSet.getRegister(binary.getUIntFromBits(21, 5)), regSet.getRegister(binary.getUIntFromBits(16, 5)), binary.getIntFromBits(0, 16));
                    case BgtzInstruction.opcode:
                        binary.getUIntFromBits(16, 5).assertEqualsZero();
                        return new BgtzInstruction(regSet.getRegister(binary.getUIntFromBits(21, 5)), binary.getIntFromBits(0, 16));
                    case BlezInstruction.opcode:
                        binary.getUIntFromBits(16, 5).assertEqualsZero();
                        return new BlezInstruction(regSet.getRegister(binary.getUIntFromBits(21, 5)), binary.getIntFromBits(0, 16));
                    case BneInstruction.opcode:
                        return new BneInstruction(regSet.getRegister(binary.getUIntFromBits(21, 5)), regSet.getRegister(binary.getUIntFromBits(16, 5)), binary.getIntFromBits(0, 16));
                    case JInstruction.opcode:
                        return new JInstruction(binary.getUIntFromBits(0, 26));
                    case JalInstruction.opcode:
                        return new JalInstruction(binary.getUIntFromBits(0, 26));
                    case LbInstruction.opcode:
                        return new LbInstruction(regSet.getRegister(binary.getUIntFromBits(16, 5)), binary.getIntFromBits(0, 16), regSet.getRegister(binary.getUIntFromBits(21, 5)));
                    case LbuInstruction.opcode:
                        return new LbuInstruction(regSet.getRegister(binary.getUIntFromBits(16, 5)), binary.getIntFromBits(0, 16), regSet.getRegister(binary.getUIntFromBits(21, 5)));
                    case LhInstruction.opcode:
                        return new LhInstruction(regSet.getRegister(binary.getUIntFromBits(16, 5)), binary.getIntFromBits(0, 16), regSet.getRegister(binary.getUIntFromBits(21, 5)));
                    case LhuInstruction.opcode:
                        return new LhuInstruction(regSet.getRegister(binary.getUIntFromBits(16, 5)), binary.getIntFromBits(0, 16), regSet.getRegister(binary.getUIntFromBits(21, 5)));
                    case LuiInstruction.opcode:
                        binary.getUIntFromBits(21, 5).assertEqualsZero();
                        return new LuiInstruction(regSet.getRegister(binary.getUIntFromBits(16, 5)), binary.getUIntFromBits(0, 16));
                    case LwInstruction.opcode:
                        return new LwInstruction(regSet.getRegister(binary.getUIntFromBits(16, 5)), binary.getIntFromBits(0, 16), regSet.getRegister(binary.getUIntFromBits(21, 5)));
                    case LwlInstruction.opcode:
                        return new LwlInstruction(regSet.getRegister(binary.getUIntFromBits(16, 5)), binary.getIntFromBits(0, 16), regSet.getRegister(binary.getUIntFromBits(21, 5)));
                    case LwrInstruction.opcode:
                        return new LwrInstruction(regSet.getRegister(binary.getUIntFromBits(16, 5)), binary.getIntFromBits(0, 16), regSet.getRegister(binary.getUIntFromBits(21, 5)));
                    case OriInstruction.opcode:
                        return new OriInstruction(regSet.getRegister(binary.getUIntFromBits(16, 5)), regSet.getRegister(binary.getUIntFromBits(21, 5)), binary.getUIntFromBits(0, 16));
                    case SbInstruction.opcode:
                        return new SbInstruction(regSet.getRegister(binary.getUIntFromBits(16, 5)), binary.getIntFromBits(0, 16), regSet.getRegister(binary.getUIntFromBits(21, 5)));
                    case ShInstruction.opcode:
                        return new ShInstruction(regSet.getRegister(binary.getUIntFromBits(16, 5)), binary.getIntFromBits(0, 16), regSet.getRegister(binary.getUIntFromBits(21, 5)));
                    case SltiInstruction.opcode:
                        return new SltiInstruction(regSet.getRegister(binary.getUIntFromBits(16, 5)), regSet.getRegister(binary.getUIntFromBits(21, 5)), binary.getIntFromBits(0, 16));
                    case SltiuInstruction.opcode:
                        return new SltiuInstruction(regSet.getRegister(binary.getUIntFromBits(16, 5)), regSet.getRegister(binary.getUIntFromBits(21, 5)), binary.getIntFromBits(0, 16));
                    case SwInstruction.opcode:
                        return new SwInstruction(regSet.getRegister(binary.getUIntFromBits(16, 5)), binary.getIntFromBits(0, 16), regSet.getRegister(binary.getUIntFromBits(21, 5)));
                    case SwlInstruction.opcode:
                        return new SwlInstruction(regSet.getRegister(binary.getUIntFromBits(16, 5)), binary.getIntFromBits(0, 16), regSet.getRegister(binary.getUIntFromBits(21, 5)));
                    case SwrInstruction.opcode:
                        return new SwrInstruction(regSet.getRegister(binary.getUIntFromBits(16, 5)), binary.getIntFromBits(0, 16), regSet.getRegister(binary.getUIntFromBits(21, 5)));
                    case XoriInstruction.opcode:
                        return new XoriInstruction(regSet.getRegister(binary.getUIntFromBits(16, 5)), regSet.getRegister(binary.getUIntFromBits(21, 5)), binary.getUIntFromBits(0, 16));
                    default:
                        throw new ArgumentException(string.Format("Unknown instruction: {0:x8}.", binary));
                }
            }
        }
    }
}
