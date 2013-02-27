using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsDasm
{
    public abstract class Instruction
    {
        public const int opcode = 0;
        protected string name;

        private Instruction()
        {

        }

        public Instruction(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }


    public abstract class SpecialInstruction : Instruction
    {
        public new const int opcode = 0;

        public SpecialInstruction(string name)
            : base(name)
        {

        }
    }

    public abstract class RegimmInstruction : Instruction
    {
        public new const int opcode = 1;

        public RegimmInstruction(string name)
            : base(name)
        {

        }
    }

    public abstract class Cop0Instruction : Instruction
    {
        public new const int opcode = 16;

        public Cop0Instruction(string name)
            : base(name)
        {

        }
    }

    public abstract class Cop2Instruction : Instruction
    {
        public new const int opcode = 18;

        public Cop2Instruction(string name)
            : base(name)
        {

        }
    }

    public abstract class ImmediateInstruction : Instruction
    {
        protected Register rt;
        protected Register rs;
        protected int immediate;

        public ImmediateInstruction(string name, Register rt, Register rs, int immediate)
            : base(name)
        {
            this.rt = rt;
            this.rs = rs;
            this.immediate = immediate;
        }

        public override string ToString()
        {
            return string.Format("{1}\t{2}, {3}, ${4:x4}", name, rt, rs, immediate);
        }
    }

    public abstract class RegisterInstruction : SpecialInstruction
    {
        protected Register rd;
        protected Register rs;
        protected Register rt;

        public RegisterInstruction(string name, Register rd, Register rs, Register rt)
            : base(name)
        {
            this.rd = rd;
            this.rs = rs;
            this.rt = rt;
        }

        public override string ToString()
        {
            return string.Format("{1}\t{2}, {3}, {4}", name, rd, rs, rt);
        }
    }

    public abstract class LoadStoreInstruction : Instruction
    {
        protected Register rt;
        protected int offset;
        protected Register @base;

        public LoadStoreInstruction(string name, Register rt, int offset, Register @base)
            : base(name)
        {
            this.rt = rt;
            this.offset = offset;
            this.@base = @base;
        }

        public override string ToString()
        {
            return string.Format("{1}\t{2}, ${3:x4}({4})", name, rt, offset, @base);
        }
    }

    public abstract class ImmediateShiftInstruction : SpecialInstruction
    {
        protected Register rd;
        protected Register rt;
        protected int shamt;

        public ImmediateShiftInstruction(string name, Register rd, Register rt, int shamt)
            : base(name)
        {
            this.rd = rd;
            this.rt = rt;
            this.shamt = shamt;
        }

        public override string ToString()
        {
            return string.Format("{1}\t{2}, {3}, ${4:x2}", name, rd, rt, shamt);
        }
    }

    public abstract class RegisterShiftInstruction : SpecialInstruction
    {
        protected Register rd;
        protected Register rt;
        protected Register rs;

        public RegisterShiftInstruction(string name, Register rd, Register rt, Register rs)
            : base(name)
        {
            this.rd = rd;
            this.rt = rt;
            this.rs = rs;
        }

        public override string ToString()
        {
            return string.Format("{1}\t{2}, {3}, {4}", name, rd, rt, rs);
        }
    }

    public abstract class MultDivInstruction : SpecialInstruction
    {
        protected Register rs;
        protected Register rt;

        public MultDivInstruction(string name, Register rs, Register rt)
            : base(name)
        {
            this.rs = rs;
            this.rt = rt;
        }

        public override string ToString()
        {
            return string.Format("{1}\t{2}, {3}", name, rs, rt);
        }
    }

    public abstract class MultDivMoveFromInstruction : SpecialInstruction
    {
        protected Register rd;

        public MultDivMoveFromInstruction(string name, Register rd)
            : base(name)
        {
            this.rd = rd;
        }

        public override string ToString()
        {
            return string.Format("{1}\t{2}", name, rd);
        }
    }

    public abstract class MultDivMoveToInstruction : SpecialInstruction
    {
        protected Register rs;

        public MultDivMoveToInstruction(string name, Register rs)
            : base(name)
        {
            this.rs = rs;
        }

        public override string ToString()
        {
            return string.Format("{1}\t{2}", name, rs);
        }
    }

    public abstract class JumpTargetInstruction : Instruction
    {
        protected int target;

        public JumpTargetInstruction(string name, int target)
            : base(name)
        {
            this.target = target << 2;
        }

        public override string ToString()
        {
            return string.Format("{1}\t${2:x8}", name, target);
        }
    }

    public abstract class BranchRegisterInstruction : Instruction
    {
        protected Register rs;
        protected Register rt;
        protected int offset;

        public BranchRegisterInstruction(string name, Register rs, Register rt, int offset)
            : base(name)
        {
            this.rs = rs;
            this.rt = rt;
            this.offset = offset << 2;
        }

        public override string ToString()
        {
            return string.Format("{1}\t{2}, {3}, ${4:x8}", name, rs, rt, offset);
        }
    }

    public abstract class BranchInstruction : Instruction
    {
        protected Register rs;
        protected int offset;

        public BranchInstruction(string name, Register rs, int offset)
            : base(name)
        {
            this.rs = rs;
            this.offset = offset << 2;
        }

        public override string ToString()
        {
            return string.Format("{1}\t{2}, ${3:x8}", name, rs, offset);
        }
    }

    public abstract class BranchRegimmInstruction : RegimmInstruction
    {
        protected Register rs;
        protected int offset;

        public BranchRegimmInstruction(string name, Register rs, int offset)
            : base(name)
        {
            this.rs = rs;
            this.offset = offset << 2;
        }

        public override string ToString()
        {
            return string.Format("{1}\t{2}, ${3:x8}", name, rs, offset);
        }
    }

    public abstract class ExceptionInstruction : SpecialInstruction
    {
        protected int code;

        public ExceptionInstruction(string name, int code)
            : base(name)
        {
            this.code = code;
        }

        public override string ToString()
        {
            if (code != 0)
                return string.Format("{1}\t${2:x3}", name, code);
            else
                return base.ToString();
        }
    }

    public abstract class Cop0MoveInstruction : Cop0Instruction
    {
        protected Register rt;
        protected Register rd;

        public Cop0MoveInstruction(string name, Register rt, Register rd)
            : base(name)
        {
            this.rt = rt;
            this.rd = rd;
        }

        public override string ToString()
        {
            return string.Format("{1}\t{2}, {3}", name, rt, rd);
        }
    }

    public abstract class Cop2MoveInstruction : Cop2Instruction
    {
        protected Register rt;
        protected Register rs;

        public Cop2MoveInstruction(string name, Register rt, Register rs)
            : base(name)
        {
            this.rt = rt;
            this.rs = rs;
        }

        public override string ToString()
        {
            return string.Format("{1}\t{2}, {3}", name, rt, rs);
        }
    }


    public sealed class NopInstruction : Instruction
    {
        public new const int opcode = 8;

        public NopInstruction()
            : base("nop")
        {

        }
    }

    #region Immediate instructions

    public sealed class AddiInstruction : ImmediateInstruction
    {
        public new const int opcode = 8;

        public AddiInstruction(Register rt, Register rs, int immediate)
            : base("addi", rt, rs, immediate)
        {

        }
    }

    public sealed class AddiuInstruction : ImmediateInstruction
    {
        public new const int opcode = 9;

        public AddiuInstruction(Register rt, Register rs, int immediate)
            : base("addiu", rt, rs, immediate)
        {

        }
    }

    public sealed class SltiInstruction : ImmediateInstruction
    {
        public new const int opcode = 10;

        public SltiInstruction(Register rt, Register rs, int immediate)
            : base("slti", rt, rs, immediate)
        {

        }
    }

    public sealed class SltiuInstruction : ImmediateInstruction
    {
        public new const int opcode = 11;

        public SltiuInstruction(Register rt, Register rs, int immediate)
            : base("sltiu", rt, rs, immediate)
        {

        }
    }

    public sealed class AndiInstruction : ImmediateInstruction
    {
        public new const int opcode = 12;

        public AndiInstruction(Register rt, Register rs, int immediate)
            : base("andi", rt, rs, immediate)
        {

        }
    }

    public sealed class OriInstruction : ImmediateInstruction
    {
        public new const int opcode = 13;

        public OriInstruction(Register rt, Register rs, int immediate)
            : base("ori", rt, rs, immediate)
        {

        }
    }

    public sealed class XoriInstruction : ImmediateInstruction
    {
        public new const int opcode = 14;

        public XoriInstruction(Register rt, Register rs, int immediate)
            : base("xori", rt, rs, immediate)
        {

        }
    }

    #endregion

    public sealed class LuiInstruction : Instruction
    {
        public new const int opcode = 15;
        private Register rt;
        private int immediate;

        public LuiInstruction(Register rt, int immediate)
            : base("lui")
        {
            this.rt = rt;
            this.immediate = immediate << 16;
        }

        public override string ToString()
        {
            return string.Format("{1}\t{2}, ${3:x4}", name, rt, immediate);
        }
    }

    #region Register instructions

    public sealed class AddInstruction : RegisterInstruction
    {
        public new const int opcode = 32;

        public AddInstruction(Register rd, Register rs, Register rt)
            : base("add", rd, rs, rt)
        {

        }
    }

    public sealed class AdduInstruction : RegisterInstruction
    {
        public new const int opcode = 33;

        public AdduInstruction(Register rd, Register rs, Register rt)
            : base("addu", rd, rs, rt)
        {

        }
    }

    public sealed class SubInstruction : RegisterInstruction
    {
        public new const int opcode = 34;

        public SubInstruction(Register rd, Register rs, Register rt)
            : base("sub", rd, rs, rt)
        {

        }
    }

    public sealed class SubuInstruction : RegisterInstruction
    {
        public new const int opcode = 35;

        public SubuInstruction(Register rd, Register rs, Register rt)
            : base("subu", rd, rs, rt)
        {

        }
    }

    public sealed class SltInstruction : RegisterInstruction
    {
        public new const int opcode = 42;

        public SltInstruction(Register rd, Register rs, Register rt)
            : base("slt", rd, rs, rt)
        {

        }
    }

    public sealed class SltuInstruction : RegisterInstruction
    {
        public new const int opcode = 43;

        public SltuInstruction(Register rd, Register rs, Register rt)
            : base("sltu", rd, rs, rt)
        {

        }
    }

    public sealed class AndInstruction : RegisterInstruction
    {
        public new const int opcode = 36;

        public AndInstruction(Register rd, Register rs, Register rt)
            : base("and", rd, rs, rt)
        {

        }
    }

    public sealed class OrInstruction : RegisterInstruction
    {
        public new const int opcode = 37;

        public OrInstruction(Register rd, Register rs, Register rt)
            : base("or", rd, rs, rt)
        {

        }
    }

    public sealed class XorInstruction : RegisterInstruction
    {
        public new const int opcode = 38;

        public XorInstruction(Register rd, Register rs, Register rt)
            : base("xor", rd, rs, rt)
        {

        }
    }

    public sealed class NorInstruction : RegisterInstruction
    {
        public new const int opcode = 39;

        public NorInstruction(Register rd, Register rs, Register rt)
            : base("nor", rd, rs, rt)
        {

        }
    }

    #endregion

    #region Load\store instructions

    public sealed class LbInstruction : LoadStoreInstruction
    {
        public new const int opcode = 32;

        public LbInstruction(Register rt, int offset, Register @base)
            : base("lb", rt, offset, @base)
        {

        }
    }

    public sealed class LbuInstruction : LoadStoreInstruction
    {
        public new const int opcode = 36;

        public LbuInstruction(Register rt, int offset, Register @base)
            : base("lbu", rt, offset, @base)
        {

        }
    }

    public sealed class LhInstruction : LoadStoreInstruction
    {
        public new const int opcode = 33;

        public LhInstruction(Register rt, int offset, Register @base)
            : base("lh", rt, offset, @base)
        {

        }
    }

    public sealed class LhuInstruction : LoadStoreInstruction
    {
        public new const int opcode = 37;

        public LhuInstruction(Register rt, int offset, Register @base)
            : base("lhu", rt, offset, @base)
        {

        }
    }

    public sealed class LwInstruction : LoadStoreInstruction
    {
        public new const int opcode = 35;

        public LwInstruction(Register rt, int offset, Register @base)
            : base("lw", rt, offset, @base)
        {

        }
    }

    public sealed class LwlInstruction : LoadStoreInstruction
    {
        public new const int opcode = 34;

        public LwlInstruction(Register rt, int offset, Register @base)
            : base("lwl", rt, offset, @base)
        {

        }
    }

    public sealed class LwrInstruction : LoadStoreInstruction
    {
        public new const int opcode = 38;

        public LwrInstruction(Register rt, int offset, Register @base)
            : base("lwr", rt, offset, @base)
        {

        }
    }

    public sealed class SbInstruction : LoadStoreInstruction
    {
        public new const int opcode = 40;

        public SbInstruction(Register rt, int offset, Register @base)
            : base("sb", rt, offset, @base)
        {

        }
    }

    public sealed class ShInstruction : LoadStoreInstruction
    {
        public new const int opcode = 41;

        public ShInstruction(Register rt, int offset, Register @base)
            : base("sh", rt, offset, @base)
        {

        }
    }

    public sealed class SwInstruction : LoadStoreInstruction
    {
        public new const int opcode = 43;

        public SwInstruction(Register rt, int offset, Register @base)
            : base("sw", rt, offset, @base)
        {

        }
    }

    public sealed class SwlInstruction : LoadStoreInstruction
    {
        public new const int opcode = 42;

        public SwlInstruction(Register rt, int offset, Register @base)
            : base("swl", rt, offset, @base)
        {

        }
    }

    public sealed class SwrInstruction : LoadStoreInstruction
    {
        public new const int opcode = 46;

        public SwrInstruction(Register rt, int offset, Register @base)
            : base("swr", rt, offset, @base)
        {

        }
    }

    #endregion

    #region Immediate shift instructions

    public sealed class SllInstruction : ImmediateShiftInstruction
    {
        public new const int opcode = 0;

        public SllInstruction(Register rd, Register rt, int shamt)
            : base("sll", rd, rt, shamt)
        {

        }
    }

    public sealed class SrlInstruction : ImmediateShiftInstruction
    {
        public new const int opcode = 2;

        public SrlInstruction(Register rd, Register rt, int shamt)
            : base("srl", rd, rt, shamt)
        {

        }
    }

    public sealed class SraInstruction : ImmediateShiftInstruction
    {
        public new const int opcode = 3;

        public SraInstruction(Register rd, Register rt, int shamt)
            : base("sra", rd, rt, shamt)
        {

        }
    }

    #endregion

    #region Register shift instructions

    public sealed class SllvInstruction : RegisterShiftInstruction
    {
        public new const int opcode = 4;

        public SllvInstruction(Register rd, Register rt, Register rs)
            : base("sllv", rd, rt, rs)
        {

        }
    }

    public sealed class SrlvInstruction : RegisterShiftInstruction
    {
        public new const int opcode = 6;

        public SrlvInstruction(Register rd, Register rt, Register rs)
            : base("srlv", rd, rt, rs)
        {

        }
    }

    public sealed class SravInstruction : RegisterShiftInstruction
    {
        public new const int opcode = 7;

        public SravInstruction(Register rd, Register rt, Register rs)
            : base("srav", rd, rt, rs)
        {

        }
    }

    #endregion

    #region Mult\div instructions

    public sealed class MultInstruction : MultDivInstruction
    {
        public new const int opcode = 24;

        public MultInstruction(Register rs, Register rt)
            : base("mult", rs, rt)
        {

        }
    }

    public sealed class MultuInstruction : MultDivInstruction
    {
        public new const int opcode = 25;

        public MultuInstruction(Register rs, Register rt)
            : base("multu", rs, rt)
        {

        }
    }

    public sealed class DivInstruction : MultDivInstruction
    {
        public new const int opcode = 26;

        public DivInstruction(Register rs, Register rt)
            : base("div", rs, rt)
        {

        }
    }

    public sealed class DivuInstruction : MultDivInstruction
    {
        public new const int opcode = 27;

        public DivuInstruction(Register rs, Register rt)
            : base("divu", rs, rt)
        {

        }
    }

    #endregion

    #region Mult\div move instructions

    public sealed class MfhiInstruction : MultDivMoveFromInstruction
    {
        public new const int opcode = 16;

        public MfhiInstruction(Register rd)
            : base("mfhi", rd)
        {

        }
    }

    public sealed class MfloInstruction : MultDivMoveFromInstruction
    {
        public new const int opcode = 18;

        public MfloInstruction(Register rd)
            : base("mflo", rd)
        {

        }
    }

    public sealed class MthiInstruction : MultDivMoveToInstruction
    {
        public new const int opcode = 17;

        public MthiInstruction(Register rs)
            : base("mthi", rs)
        {

        }
    }

    public sealed class MtloInstruction : MultDivMoveToInstruction
    {
        public new const int opcode = 19;

        public MtloInstruction(Register rs)
            : base("mtlo", rs)
        {

        }
    }

    #endregion

    #region Jump target instructions

    public sealed class JInstruction : JumpTargetInstruction
    {
        public new const int opcode = 2;

        public JInstruction(int target)
            : base("j", target)
        {

        }
    }

    public sealed class JalInstruction : JumpTargetInstruction
    {
        public new const int opcode = 3;

        public JalInstruction(int target)
            : base("jal", target)
        {

        }
    }

    #endregion

    public sealed class JrInstruction : SpecialInstruction
    {
        public new const int opcode = 8;
        private Register rs;

        public JrInstruction(Register rs)
            : base("jr")
        {
            this.rs = rs;
        }

        public override string ToString()
        {
            return string.Format("{1}\t{2}", name, rs);
        }
    }

    public sealed class JalrInstruction : SpecialInstruction
    {
        public new const int opcode = 9;
        private Register rd;
        private Register rs;

        public JalrInstruction(Register rd, Register rs)
            : base("jalr")
        {
            this.rd = rd;
            this.rs = rs;
        }

        public override string ToString()
        {
            if (rd.GetType() == typeof(R31ra))
                return string.Format("{1}\t{2}", name, rs);
            else
                return string.Format("{1}\t{2}, {3}", name, rd, rs);
        }
    }

    #region Branch register instruction

    public sealed class BeqInstruction : BranchRegisterInstruction
    {
        public new const int opcode = 4;

        public BeqInstruction(Register rs, Register rt, int offset)
            : base("beq", rs, rt, offset)
        {

        }
    }

    public sealed class BneInstruction : BranchRegisterInstruction
    {
        public new const int opcode = 5;

        public BneInstruction(Register rs, Register rt, int offset)
            : base("bne", rs, rt, offset)
        {

        }
    }

    #endregion

    #region Branch instructions

    public sealed class BlezInstruction : BranchInstruction
    {
        public new const int opcode = 6;

        public BlezInstruction(Register rs, int offset)
            : base("blez", rs, offset)
        {

        }
    }

    public sealed class BgtzInstruction : BranchInstruction
    {
        public new const int opcode = 7;

        public BgtzInstruction(Register rs, int offset)
            : base("bgtz", rs, offset)
        {

        }
    }

    public sealed class BltzInstruction : BranchRegimmInstruction
    {
        public new const int opcode = 0;

        public BltzInstruction(Register rs, int offset)
            : base("bltz", rs, offset)
        {

        }
    }

    public sealed class BgezInstruction : BranchRegimmInstruction
    {
        public new const int opcode = 1;

        public BgezInstruction(Register rs, int offset)
            : base("bgez", rs, offset)
        {

        }
    }

    public sealed class BltzalInstruction : BranchRegimmInstruction
    {
        public new const int opcode = 16;

        public BltzalInstruction(Register rs, int offset)
            : base("bltzal", rs, offset)
        {

        }
    }

    public sealed class BgezalInstruction : BranchRegimmInstruction
    {
        public new const int opcode = 17;

        public BgezalInstruction(Register rs, int offset)
            : base("bgezal", rs, offset)
        {

        }
    }

    #endregion

    public sealed class SyscallInstruction : ExceptionInstruction
    {
        public new const int opcode = 12;

        public SyscallInstruction(int code)
            : base("syscall", code)
        {

        }
    }

    public sealed class BreakInstruction : ExceptionInstruction
    {
        public new const int opcode = 13;

        public BreakInstruction(int code)
            : base("break", code)
        {

        }
    }

    #region Cop0 instructions

    public sealed class Mtc0Instruction : Cop0MoveInstruction
    {
        public new const int opcode = 4;

        public Mtc0Instruction(Register rt, Register rd)
            : base("mtc0", rt, rd)
        {

        }
    }

    public sealed class Mfc0Instruction : Cop0MoveInstruction
    {
        public new const int opcode = 0;

        public Mfc0Instruction(Register rt, Register rd)
            : base("mfc0", rt, rd)
        {

        }
    }

    public sealed class TlbrInstruction : Cop0Instruction
    {
        public new const int opcode = 1;

        public TlbrInstruction()
            : base("tlbr")
        {

        }
    }

    public sealed class TlbwiInstruction : Cop0Instruction
    {
        public new const int opcode = 2;

        public TlbwiInstruction()
            : base("tlbwi")
        {

        }
    }

    public sealed class TlbwrInstruction : Cop0Instruction
    {
        public new const int opcode = 6;

        public TlbwrInstruction()
            : base("tlbwr")
        {

        }
    }

    public sealed class TlbpInstruction : Cop0Instruction
    {
        public new const int opcode = 8;

        public TlbpInstruction()
            : base("tlbp")
        {

        }
    }

    public sealed class RfeInstruction : Cop0Instruction
    {
        public new const int opcode = 16;

        public RfeInstruction()
            : base("rfe")
        {

        }
    }

    #endregion

    #region Cop2 instructions

    public sealed class Lwc2Instruction : LoadStoreInstruction
    {
        public new const int opcode = 50;

        public Lwc2Instruction(Register rt, int offset, Register @base)
            : base("lwc2", rt, offset, @base)
        {

        }
    }

    public sealed class Swc2Instruction : LoadStoreInstruction
    {
        public new const int opcode = 58;

        public Swc2Instruction(Register rt, int offset, Register @base)
            : base("swc2", rt, offset, @base)
        {

        }
    }

    public sealed class Mtc2Instruction : Cop2MoveInstruction
    {
        public new const int opcode = 4;

        public Mtc2Instruction(Register rt, Register rs)
            : base("mtc2", rt, rs)
        {

        }
    }

    public sealed class Mfc2Instruction : Cop2MoveInstruction
    {
        public new const int opcode = 0;

        public Mfc2Instruction(Register rt, Register rs)
            : base("mfc2", rt, rs)
        {

        }
    }

    public sealed class Ctc2Instruction : Cop2MoveInstruction
    {
        public new const int opcode = 6;

        public Ctc2Instruction(Register rt, Register rs)
            : base("ctc2", rt, rs)
        {

        }
    }

    public sealed class Cfc2Instruction : Cop2MoveInstruction
    {
        public new const int opcode = 2;

        public Cfc2Instruction(Register rt, Register rs)
            : base("cfc2", rt, rs)
        {

        }
    }

    #endregion
}
