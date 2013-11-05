using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsDasm.ps1
{
    public sealed class Ps1InstructionSet : InstructionSet
    {
        private RegisterSet cop0Rs;
        private RegisterSet cop2cRs;
        private RegisterSet cop2dRs;

        public Ps1InstructionSet()
            : this(new Ps1GprRegiserSet(), new Ps1Cop0cRegiserSet(), new Ps1Cop2cRegiserSet(), new Ps1Cop2dRegiserSet())
        {

        }

        public Ps1InstructionSet(RegisterSet gprRs, RegisterSet cop0Rs, RegisterSet cop2cRs, RegisterSet cop2dRs)
            : base(gprRs)
        {
            this.cop0Rs = cop0Rs;
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
                                binary.getUIntFromBits(6, 5).assertEqualsZero();
                                binary.getUIntFromBits(16, 5).assertEqualsZero();
                                return new JalrInstruction(gprRs.getRegister(binary.getUIntFromBits(11, 5)), gprRs.getRegister(binary.getUIntFromBits(21, 5)));
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
                    case Cop0Instruction.opcode:
                        if (binary.getUIntFromBits(25, 1) == 0)
                        {
                            switch (binary.getUIntFromBits(21, 5))
                            {
                                case Mfc0Instruction.opcode:
                                    binary.getUIntFromBits(0, 3).assertEqualsZero();
                                    binary.getUIntFromBits(3, 8).assertEqualsZero();
                                    return new Mfc0Instruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), cop0Rs.getRegister(binary.getUIntFromBits(11, 5)));
                                case Mtc0Instruction.opcode:
                                    binary.getUIntFromBits(0, 3).assertEqualsZero();
                                    binary.getUIntFromBits(3, 8).assertEqualsZero();
                                    return new Mtc0Instruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), cop0Rs.getRegister(binary.getUIntFromBits(11, 5)));
                                default:
                                    throw new ArgumentException(string.Format("Unknown instruction: {0:x8}.", binary));
                            }
                        }
                        else
                        {
                            switch (binary.getUIntFromBits(0, 6))
                            {
                                case RfeInstruction.opcode:
                                    binary.getUIntFromBits(6, 19).assertEqualsZero();
                                    return new RfeInstruction();
                                case TlbpInstruction.opcode:
                                    binary.getUIntFromBits(6, 19).assertEqualsZero();
                                    return new TlbpInstruction();
                                case TlbrInstruction.opcode:
                                    binary.getUIntFromBits(6, 19).assertEqualsZero();
                                    return new TlbrInstruction();
                                case TlbwiInstruction.opcode:
                                    binary.getUIntFromBits(6, 19).assertEqualsZero();
                                    return new TlbwiInstruction();
                                case TlbwrInstruction.opcode:
                                    binary.getUIntFromBits(6, 19).assertEqualsZero();
                                    return new TlbwrInstruction();
                                default:
                                    throw new ArgumentException(string.Format("Unknown instruction: {0:x8}.", binary));
                            }
                        }
                    case Cop2Instruction.opcode:
                        if (binary.getUIntFromBits(25, 1) == 0)
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
                        else
                        {
                            binary.getUIntFromBits(11, 2).assertEqualsZero();
                            binary.getUIntFromBits(6, 4).assertEqualsZero();
                            if (binary.getUIntFromBits(0, 6) == MvmvaInstruction.opcode)
                                return new MvmvaInstruction(binary);
                            binary.getUIntFromBits(17, 2).assertEqualsZero();
                            binary.getUIntFromBits(15, 2).assertEqualsZero();
                            binary.getUIntFromBits(13, 2).assertEqualsZero();
                            switch (binary.getUIntFromBits(0, 6))
                            {
                                case Avsz3Instruction.opcode:
                                    return new Avsz3Instruction(binary);
                                case Avsz4Instruction.opcode:
                                    return new Avsz4Instruction(binary);
                                case CcInstruction.opcode:
                                    return new CcInstruction(binary);
                                case CdpInstruction.opcode:
                                    return new CdpInstruction(binary);
                                case DcplInstruction.opcode:
                                    return new DcplInstruction(binary);
                                case DpcsInstruction.opcode:
                                    return new DpcsInstruction(binary);
                                case DpctInstruction.opcode:
                                    return new DpctInstruction(binary);
                                case GpfInstruction.opcode:
                                    return new GpfInstruction(binary);
                                case GplInstruction.opcode:
                                    return new GplInstruction(binary);
                                case IntplInstruction.opcode:
                                    return new IntplInstruction(binary);
                                case NcsInstruction.opcode:
                                    return new NcsInstruction(binary);
                                case NctInstruction.opcode:
                                    return new NctInstruction(binary);
                                case NccsInstruction.opcode:
                                    return new NccsInstruction(binary);
                                case NcctInstruction.opcode:
                                    return new NcctInstruction(binary);
                                case NcdsInstruction.opcode:
                                    return new NcdsInstruction(binary);
                                case NcdtInstruction.opcode:
                                    return new NcdtInstruction(binary);
                                case NclipInstruction.opcode:
                                    return new NclipInstruction(binary);
                                case OpInstruction.opcode:
                                    return new OpInstruction(binary);
                                case RtpsInstruction.opcode:
                                    return new RtpsInstruction(binary);
                                case RtptInstruction.opcode:
                                    return new RtptInstruction(binary);
                                case SqrInstruction.opcode:
                                    return new SqrInstruction(binary);
                                default:
                                    throw new ArgumentException(string.Format("Unknown instruction: {0:x8}.", binary));
                            }
                        }
                    case AddiInstruction.opcode:
                        return new AddiInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), gprRs.getRegister(binary.getUIntFromBits(21, 5)), binary.getUIntFromBits(0, 16));
                    case AddiuInstruction.opcode:
                        return new AddiuInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), gprRs.getRegister(binary.getUIntFromBits(21, 5)), binary.getUIntFromBits(0, 16));
                    case AndiInstruction.opcode:
                        return new AndiInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), gprRs.getRegister(binary.getUIntFromBits(21, 5)), binary.getUIntFromBits(0, 16));
                    case BeqInstruction.opcode:
                        return new BeqInstruction(gprRs.getRegister(binary.getUIntFromBits(21, 5)), gprRs.getRegister(binary.getUIntFromBits(16, 5)), binary.getUIntFromBits(0, 16));
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
                        return new LbInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), binary.getUIntFromBits(0, 16), gprRs.getRegister(binary.getUIntFromBits(21, 5)));
                    case LbuInstruction.opcode:
                        return new LbuInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), binary.getUIntFromBits(0, 16), gprRs.getRegister(binary.getUIntFromBits(21, 5)));
                    case LhInstruction.opcode:
                        return new LhInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), binary.getUIntFromBits(0, 16), gprRs.getRegister(binary.getUIntFromBits(21, 5)));
                    case LhuInstruction.opcode:
                        return new LhuInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), binary.getUIntFromBits(0, 16), gprRs.getRegister(binary.getUIntFromBits(21, 5)));
                    case LuiInstruction.opcode:
                        binary.getUIntFromBits(21, 5).assertEqualsZero();
                        return new LuiInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), binary.getUIntFromBits(0, 16));
                    case LwInstruction.opcode:
                        return new LwInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), binary.getUIntFromBits(0, 16), gprRs.getRegister(binary.getUIntFromBits(21, 5)));
                    case Lwc2Instruction.opcode:
                        return new Lwc2Instruction(cop2dRs.getRegister(binary.getUIntFromBits(16, 5)), binary.getUIntFromBits(0, 16), gprRs.getRegister(binary.getUIntFromBits(21, 5)));
                    case LwlInstruction.opcode:
                        return new LwlInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), binary.getUIntFromBits(0, 16), gprRs.getRegister(binary.getUIntFromBits(21, 5)));
                    case LwrInstruction.opcode:
                        return new LwrInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), binary.getUIntFromBits(0, 16), gprRs.getRegister(binary.getUIntFromBits(21, 5)));
                    case OriInstruction.opcode:
                        return new OriInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), gprRs.getRegister(binary.getUIntFromBits(21, 5)), binary.getUIntFromBits(0, 16));
                    case SbInstruction.opcode:
                        return new SbInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), binary.getUIntFromBits(0, 16), gprRs.getRegister(binary.getUIntFromBits(21, 5)));
                    case ShInstruction.opcode:
                        return new ShInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), binary.getUIntFromBits(0, 16), gprRs.getRegister(binary.getUIntFromBits(21, 5)));
                    case SltiInstruction.opcode:
                        return new SltiInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), gprRs.getRegister(binary.getUIntFromBits(21, 5)), binary.getUIntFromBits(0, 16));
                    case SltiuInstruction.opcode:
                        return new SltiuInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), gprRs.getRegister(binary.getUIntFromBits(21, 5)), binary.getUIntFromBits(0, 16));
                    case SwInstruction.opcode:
                        return new SwInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), binary.getUIntFromBits(0, 16), gprRs.getRegister(binary.getUIntFromBits(21, 5)));
                    case Swc2Instruction.opcode:
                        return new Swc2Instruction(cop2dRs.getRegister(binary.getUIntFromBits(16, 5)), binary.getUIntFromBits(0, 16), gprRs.getRegister(binary.getUIntFromBits(21, 5)));
                    case SwlInstruction.opcode:
                        return new SwlInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), binary.getUIntFromBits(0, 16), gprRs.getRegister(binary.getUIntFromBits(21, 5)));
                    case SwrInstruction.opcode:
                        return new SwrInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), binary.getUIntFromBits(0, 16), gprRs.getRegister(binary.getUIntFromBits(21, 5)));
                    case XoriInstruction.opcode:
                        return new XoriInstruction(gprRs.getRegister(binary.getUIntFromBits(16, 5)), gprRs.getRegister(binary.getUIntFromBits(21, 5)), binary.getUIntFromBits(0, 16));
                    default:
                        throw new ArgumentException(string.Format("Unknown instruction: {0:x8}.", binary));
                }
            }
        }
    }
}
