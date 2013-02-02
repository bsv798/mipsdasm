using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsDasm.ps1
{
    public sealed class Ps1InstructionSet : InstructionSet
    {
        private RegisterSet cop2cRs;
        private RegisterSet cop2dRs;

        public Ps1InstructionSet(RegisterSet gprRs, RegisterSet cop2cRs, RegisterSet cop2dRs)
            : base(gprRs)
        {
            this.cop2cRs = cop2cRs;
            this.cop2dRs = cop2dRs;
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
                                return new AddInstruction(gprRs.getRegister(binary.getUIntFromBits(11, 5)), gprRs.getRegister(binary.getUIntFromBits(21, 5)), gprRs.getRegister(binary.getUIntFromBits(16, 5)));
                            case AdduInstruction.opcode:
                                binary.getUIntFromBits(6, 5).assertEqualsZero();
                                return new AdduInstruction(gprRs.getRegister(binary.getUIntFromBits(11, 5)), gprRs.getRegister(binary.getUIntFromBits(21, 5)), gprRs.getRegister(binary.getUIntFromBits(16, 5)));
                            case AndInstruction.opcode:
                                binary.getUIntFromBits(6, 5).assertEqualsZero();
                                return new AndInstruction(gprRs.getRegister(binary.getUIntFromBits(11, 5)), gprRs.getRegister(binary.getUIntFromBits(21, 5)), gprRs.getRegister(binary.getUIntFromBits(16, 5)));
                            case BreakInstruction.opcode:
                                return new BreakInstruction(binary.getUIntFromBits(6, 20));
                            case DivInstruction.opcode:
                                binary.getUIntFromBits(6, 10).assertEqualsZero();
                                return new DivInstruction(gprRs.getRegister(binary.getUIntFromBits(21, 5)), gprRs.getRegister(binary.getUIntFromBits(16, 5)));
                            case DivuInstruction.opcode:
                                binary.getUIntFromBits(6, 10).assertEqualsZero();
                                return new DivuInstruction(gprRs.getRegister(binary.getUIntFromBits(21, 5)), gprRs.getRegister(binary.getUIntFromBits(16, 5)));
                            case JalrInstruction.opcode:
                                binary.getUIntFromBits(6, 10).assertEqualsZero();
                                return new JalrInstruction(gprRs.getRegister(31), gprRs.getRegister(binary.getUIntFromBits(21, 5)));
                            case JrInstruction.opcode:
                                binary.getUIntFromBits(6, 15).assertEqualsZero();
                                return new JrInstruction(gprRs.getRegister(binary.getUIntFromBits(21, 5)));
                            case MfhiInstruction.opcode:
                                binary.getUIntFromBits(6, 5).assertEqualsZero();
                                binary.getUIntFromBits(16, 10).assertEqualsZero();
                                return new MfhiInstruction(gprRs.getRegister(binary.getUIntFromBits(11, 5)));
                            case MfloInstruction.opcode:
                                binary.getUIntFromBits(6, 5).assertEqualsZero();
                                binary.getUIntFromBits(16, 10).assertEqualsZero();
                                return new MfloInstruction(gprRs.getRegister(binary.getUIntFromBits(11, 5)));
                            case MthiInstruction.opcode:
                                binary.getUIntFromBits(6, 15).assertEqualsZero();
                                return new MthiInstruction(gprRs.getRegister(binary.getUIntFromBits(21, 5)));
                            case MtloInstruction.opcode:
                                binary.getUIntFromBits(6, 15).assertEqualsZero();
                                return new MtloInstruction(gprRs.getRegister(binary.getUIntFromBits(21, 5)));
                            case MultInstruction.opcode:
                                binary.getUIntFromBits(6, 10).assertEqualsZero();
                                return new MultInstruction(gprRs.getRegister(binary.getUIntFromBits(21, 5)), gprRs.getRegister(binary.getUIntFromBits(16, 5)));
                            case MultuInstruction.opcode:
                                binary.getUIntFromBits(6, 10).assertEqualsZero();
                                return new MultuInstruction(gprRs.getRegister(binary.getUIntFromBits(21, 5)), gprRs.getRegister(binary.getUIntFromBits(16, 5)));
                            case NorInstruction.opcode:
                                binary.getUIntFromBits(6, 5).assertEqualsZero();
                                return new NorInstruction(gprRs.getRegister(binary.getUIntFromBits(11, 5)), gprRs.getRegister(binary.getUIntFromBits(21, 5)), gprRs.getRegister(binary.getUIntFromBits(16, 5)));
                            case OrInstruction.opcode:
                                binary.getUIntFromBits(6, 5).assertEqualsZero();
                                return new OrInstruction(gprRs.getRegister(binary.getUIntFromBits(11, 5)), gprRs.getRegister(binary.getUIntFromBits(21, 5)), gprRs.getRegister(binary.getUIntFromBits(16, 5)));
                            case SllInstruction.opcode:
                                binary.getUIntFromBits(21, 5).assertEqualsZero();
                                return new SllInstruction(gprRs.getRegister(binary.getUIntFromBits(11, 5)), gprRs.getRegister(binary.getUIntFromBits(16, 5)), binary.getUIntFromBits(6, 5));
                            case SllvInstruction.opcode:
                                binary.getUIntFromBits(6, 5).assertEqualsZero();
                                return new SllvInstruction(gprRs.getRegister(binary.getUIntFromBits(11, 5)), gprRs.getRegister(binary.getUIntFromBits(16, 5)), gprRs.getRegister(binary.getUIntFromBits(21, 5)));
                            case SltInstruction.opcode:
                                binary.getUIntFromBits(6, 5).assertEqualsZero();
                                return new SltInstruction(gprRs.getRegister(binary.getUIntFromBits(11, 5)), gprRs.getRegister(binary.getUIntFromBits(21, 5)), gprRs.getRegister(binary.getUIntFromBits(16, 5)));
                            case SltuInstruction.opcode:
                                binary.getUIntFromBits(6, 5).assertEqualsZero();
                                return new SltuInstruction(gprRs.getRegister(binary.getUIntFromBits(11, 5)), gprRs.getRegister(binary.getUIntFromBits(21, 5)), gprRs.getRegister(binary.getUIntFromBits(16, 5)));
                            case SraInstruction.opcode:
                                binary.getUIntFromBits(21, 5).assertEqualsZero();
                                return new SraInstruction(gprRs.getRegister(binary.getUIntFromBits(11, 5)), gprRs.getRegister(binary.getUIntFromBits(16, 5)), binary.getUIntFromBits(6, 5));
                            case SravInstruction.opcode:
                                binary.getUIntFromBits(6, 5).assertEqualsZero();
                                return new SravInstruction(gprRs.getRegister(binary.getUIntFromBits(11, 5)), gprRs.getRegister(binary.getUIntFromBits(16, 5)), gprRs.getRegister(binary.getUIntFromBits(21, 5)));
                            case SrlInstruction.opcode:
                                binary.getUIntFromBits(21, 5).assertEqualsZero();
                                return new SrlInstruction(gprRs.getRegister(binary.getUIntFromBits(11, 5)), gprRs.getRegister(binary.getUIntFromBits(16, 5)), binary.getUIntFromBits(6, 5));
                            case SrlvInstruction.opcode:
                                binary.getUIntFromBits(6, 5).assertEqualsZero();
                                return new SrlvInstruction(gprRs.getRegister(binary.getUIntFromBits(11, 5)), gprRs.getRegister(binary.getUIntFromBits(16, 5)), gprRs.getRegister(binary.getUIntFromBits(21, 5)));
                            case SubInstruction.opcode:
                                binary.getUIntFromBits(6, 5).assertEqualsZero();
                                return new SubInstruction(gprRs.getRegister(binary.getUIntFromBits(11, 5)), gprRs.getRegister(binary.getUIntFromBits(21, 5)), gprRs.getRegister(binary.getUIntFromBits(16, 5)));
                            case SubuInstruction.opcode:
                                binary.getUIntFromBits(6, 5).assertEqualsZero();
                                return new SubuInstruction(gprRs.getRegister(binary.getUIntFromBits(11, 5)), gprRs.getRegister(binary.getUIntFromBits(21, 5)), gprRs.getRegister(binary.getUIntFromBits(16, 5)));
                            case SyscallInstruction.opcode:
                                return new SyscallInstruction(binary.getUIntFromBits(6, 20));
                            case XorInstruction.opcode:
                                binary.getUIntFromBits(6, 5).assertEqualsZero();
                                return new XorInstruction(gprRs.getRegister(binary.getUIntFromBits(11, 5)), gprRs.getRegister(binary.getUIntFromBits(21, 5)), gprRs.getRegister(binary.getUIntFromBits(16, 5)));
                            default:
                                throw new ArgumentException(string.Format("Unknown instruction: {0:x8}.", binary));
                        }
                    case RegimmInstruction.opcode:
                        switch (binary.getUIntFromBits(16, 5))
                        {
                            case BgezInstruction.opcode:
                                return new BgezInstruction(gprRs.getRegister(binary.getUIntFromBits(21, 5)), binary.getIntFromBits(0, 16));
                            case BgezalInstruction.opcode:
                                return new BgezalInstruction(gprRs.getRegister(binary.getUIntFromBits(21, 5)), binary.getIntFromBits(0, 16));
                            case BltzInstruction.opcode:
                                return new BltzInstruction(gprRs.getRegister(binary.getUIntFromBits(21, 5)), binary.getIntFromBits(0, 16));
                            case BltzalInstruction.opcode:
                                return new BltzalInstruction(gprRs.getRegister(binary.getUIntFromBits(21, 5)), binary.getIntFromBits(0, 16));
                            default:
                                throw new ArgumentException(string.Format("Unknown instruction: {0:x8}.", binary));
                        }
                    case Cop2Instruction.opcode:
                        {
                            switch (binary.getUIntFromBits(21, 5))
                            {
                                case Cfc2Instruction.opcode:
                                  binary.getUIntFromBits(0, 11).assertEqualsZero();
                                  return new Cfc2Instruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), cop2cRs.getRegister(binary.getUIntFromBits(11, 5)));
                                case Ctc2Instruction.opcode:
                                  binary.getUIntFromBits(0, 11).assertEqualsZero();
                                  return new Ctc2Instruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), cop2cRs.getRegister(binary.getUIntFromBits(11, 5)));
                                case Mfc2Instruction.opcode:
                                  binary.getUIntFromBits(0, 11).assertEqualsZero();
                                  return new Mfc2Instruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), cop2dRs.getRegister(binary.getUIntFromBits(11, 5)));
                                case Mtc2Instruction.opcode:
                                  binary.getUIntFromBits(0, 11).assertEqualsZero();
                                  return new Mtc2Instruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), cop2dRs.getRegister(binary.getUIntFromBits(11, 5)));
                                default:
                                throw new ArgumentException(string.Format("Unknown instruction: {0:x8}.", binary));
                            }
                        }
                    case AddiInstruction.opcode:
                        return new AddiInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), gprRs.getRegister(binary.getUIntFromBits(21, 5)), binary.getIntFromBits(0, 16));
                    case AddiuInstruction.opcode:
                        return new AddiuInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), gprRs.getRegister(binary.getUIntFromBits(21, 5)), binary.getIntFromBits(0, 16));
                    case AndiInstruction.opcode:
                        return new AndiInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), gprRs.getRegister(binary.getUIntFromBits(21, 5)), binary.getUIntFromBits(0, 16));
                    case BeqInstruction.opcode:
                        return new BeqInstruction(gprRs.getRegister(binary.getUIntFromBits(21, 5)), gprRs.getRegister(binary.getUIntFromBits(16, 5)), binary.getIntFromBits(0, 16));
                    case BgtzInstruction.opcode:
                        binary.getUIntFromBits(16, 5).assertEqualsZero();
                        return new BgtzInstruction(gprRs.getRegister(binary.getUIntFromBits(21, 5)), binary.getIntFromBits(0, 16));
                    case BlezInstruction.opcode:
                        binary.getUIntFromBits(16, 5).assertEqualsZero();
                        return new BlezInstruction(gprRs.getRegister(binary.getUIntFromBits(21, 5)), binary.getIntFromBits(0, 16));
                    case BneInstruction.opcode:
                        return new BneInstruction(gprRs.getRegister(binary.getUIntFromBits(21, 5)), gprRs.getRegister(binary.getUIntFromBits(16, 5)), binary.getIntFromBits(0, 16));
                    case JInstruction.opcode:
                        return new JInstruction(binary.getUIntFromBits(0, 26));
                    case JalInstruction.opcode:
                        return new JalInstruction(binary.getUIntFromBits(0, 26));
                    case LbInstruction.opcode:
                        return new LbInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), binary.getIntFromBits(0, 16), gprRs.getRegister(binary.getUIntFromBits(21, 5)));
                    case LbuInstruction.opcode:
                        return new LbuInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), binary.getIntFromBits(0, 16), gprRs.getRegister(binary.getUIntFromBits(21, 5)));
                    case LhInstruction.opcode:
                        return new LhInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), binary.getIntFromBits(0, 16), gprRs.getRegister(binary.getUIntFromBits(21, 5)));
                    case LhuInstruction.opcode:
                        return new LhuInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), binary.getIntFromBits(0, 16), gprRs.getRegister(binary.getUIntFromBits(21, 5)));
                    case LuiInstruction.opcode:
                        binary.getUIntFromBits(21, 5).assertEqualsZero();
                        return new LuiInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), binary.getUIntFromBits(0, 16));
                    case LwInstruction.opcode:
                        return new LwInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), binary.getIntFromBits(0, 16), gprRs.getRegister(binary.getUIntFromBits(21, 5)));
                    case Lwc2Instruction.opcode:
                        return new Lwc2Instruction(cop2dRs.getRegister(binary.getUIntFromBits(16, 5)), binary.getIntFromBits(0, 16), gprRs.getRegister(binary.getUIntFromBits(21, 5)));
                    case LwlInstruction.opcode:
                        return new LwlInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), binary.getIntFromBits(0, 16), gprRs.getRegister(binary.getUIntFromBits(21, 5)));
                    case LwrInstruction.opcode:
                        return new LwrInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), binary.getIntFromBits(0, 16), gprRs.getRegister(binary.getUIntFromBits(21, 5)));
                    case OriInstruction.opcode:
                        return new OriInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), gprRs.getRegister(binary.getUIntFromBits(21, 5)), binary.getUIntFromBits(0, 16));
                    case SbInstruction.opcode:
                        return new SbInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), binary.getIntFromBits(0, 16), gprRs.getRegister(binary.getUIntFromBits(21, 5)));
                    case ShInstruction.opcode:
                        return new ShInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), binary.getIntFromBits(0, 16), gprRs.getRegister(binary.getUIntFromBits(21, 5)));
                    case SltiInstruction.opcode:
                        return new SltiInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), gprRs.getRegister(binary.getUIntFromBits(21, 5)), binary.getIntFromBits(0, 16));
                    case SltiuInstruction.opcode:
                        return new SltiuInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), gprRs.getRegister(binary.getUIntFromBits(21, 5)), binary.getIntFromBits(0, 16));
                    case SwInstruction.opcode:
                        return new SwInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), binary.getIntFromBits(0, 16), gprRs.getRegister(binary.getUIntFromBits(21, 5)));
                    case Swc2Instruction.opcode:
                        return new Swc2Instruction(cop2dRs.getRegister(binary.getUIntFromBits(16, 5)), binary.getIntFromBits(0, 16), gprRs.getRegister(binary.getUIntFromBits(21, 5)));
                    case SwlInstruction.opcode:
                        return new SwlInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), binary.getIntFromBits(0, 16), gprRs.getRegister(binary.getUIntFromBits(21, 5)));
                    case SwrInstruction.opcode:
                        return new SwrInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), binary.getIntFromBits(0, 16), gprRs.getRegister(binary.getUIntFromBits(21, 5)));
                    case XoriInstruction.opcode:
                        return new XoriInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), gprRs.getRegister(binary.getUIntFromBits(21, 5)), binary.getUIntFromBits(0, 16));
                    default:
                        throw new ArgumentException(string.Format("Unknown instruction: {0:x8}.", binary));
                }
            }
        }
    }
}
