using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mipsDasm
{
    public abstract class Instruction
    {
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


    public abstract class ImmediateInstruction : Instruction
    {
        protected Register rt;
        protected Register rs;
        protected short immediate;

        public ImmediateInstruction(string name, Register rt, Register rs, short immediate)
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

    public abstract class RegisterInstruction : Instruction
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
        protected short offset;
        protected Register @base;

        public LoadStoreInstruction(string name, Register rt, short offset, Register @base)
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

    public abstract class ImmediateShiftInstruction : ImmediateInstruction
    {
        public ImmediateShiftInstruction(string name, Register rt, Register rs, short immediate)
            : base(name, rt, rs, immediate)
        {

        }

        public override string ToString()
        {
            return string.Format("{1}\t{2}, {3}, ${4:x2}", name, rt, rs, immediate);
        }
    }

    public abstract class RegisterShiftInstruction : RegisterInstruction
    {
        public RegisterShiftInstruction(string name, Register rd, Register rs, Register rt)
            : base(name, rd, rs, rt)
        {

        }
    }

    public abstract class MultDivInstruction : Instruction
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

    public abstract class MultDivMoveInstruction : Instruction
    {
        protected Register rd;

        public MultDivMoveInstruction(string name, Register rd)
            : base(name)
        {
            this.rd = rd;
        }

        public override string ToString()
        {
            return string.Format("{1}\t{2}", name, rd);
        }
    }

    public abstract class JumpTargetInstruction : Instruction
    {
        protected int target;

        public JumpTargetInstruction(string name, int target)
            : base(name)
        {
            this.target = target;
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
            this.offset = offset;
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
            this.offset = offset;
        }

        public override string ToString()
        {
            return string.Format("{1}\t{2}, ${3:x8}", name, rs, offset);
        }
    }

    public abstract class ExceptionInstruction : Instruction
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


    public sealed class NopInstruction : Instruction
    {
        public NopInstruction()
            : base("nop")
        {

        }
    }

    #region Immediate instructions

    public sealed class AddiInstruction : ImmediateInstruction
    {
        public AddiInstruction(Register rt, Register rs, short immediate)
            : base("addi", rt, rs, immediate)
        {

        }
    }

    public sealed class AddiuInstruction : ImmediateInstruction
    {
        public AddiuInstruction(Register rt, Register rs, short immediate)
            : base("addiu", rt, rs, immediate)
        {

        }
    }

    public sealed class SltiInstruction : ImmediateInstruction
    {
        public SltiInstruction(Register rt, Register rs, short immediate)
            : base("slti", rt, rs, immediate)
        {

        }
    }

    public sealed class SltiuInstruction : ImmediateInstruction
    {
        public SltiuInstruction(Register rt, Register rs, short immediate)
            : base("sltiu", rt, rs, immediate)
        {

        }
    }

    public sealed class AndiInstruction : ImmediateInstruction
    {
        public AndiInstruction(Register rt, Register rs, short immediate)
            : base("andi", rt, rs, immediate)
        {

        }
    }

    public sealed class OriInstruction : ImmediateInstruction
    {
        public OriInstruction(Register rt, Register rs, short immediate)
            : base("ori", rt, rs, immediate)
        {

        }
    }

    public sealed class XoriInstruction : ImmediateInstruction
    {
        public XoriInstruction(Register rt, Register rs, short immediate)
            : base("xori", rt, rs, immediate)
        {

        }
    }

    #endregion

    public sealed class LuiInstruction : Instruction
    {
        private Register rt;
        private short immediate;

        public LuiInstruction(Register rt, short immediate)
            : base("lui")
        {
            this.rt = rt;
            this.immediate = immediate;
        }

        public override string ToString()
        {
            return string.Format("{1}\t{2}, ${3:x4}", name, rt, immediate);
        }
    }

    #region Register instructions

    public sealed class AddInstruction : RegisterInstruction
    {
        public AddInstruction(Register rd, Register rs, Register rt)
            : base("add", rd, rs, rt)
        {

        }
    }

    public sealed class AdduInstruction : RegisterInstruction
    {
        public AdduInstruction(Register rd, Register rs, Register rt)
            : base("addu", rd, rs, rt)
        {

        }
    }

    public sealed class SubInstruction : RegisterInstruction
    {
        public SubInstruction(Register rd, Register rs, Register rt)
            : base("sub", rd, rs, rt)
        {

        }
    }

    public sealed class SubuInstruction : RegisterInstruction
    {
        public SubuInstruction(Register rd, Register rs, Register rt)
            : base("subu", rd, rs, rt)
        {

        }
    }

    public sealed class SltInstruction : RegisterInstruction
    {
        public SltInstruction(Register rd, Register rs, Register rt)
            : base("slt", rd, rs, rt)
        {

        }
    }

    public sealed class SltuInstruction : RegisterInstruction
    {
        public SltuInstruction(Register rd, Register rs, Register rt)
            : base("sltu", rd, rs, rt)
        {

        }
    }

    public sealed class AndInstruction : RegisterInstruction
    {
        public AndInstruction(Register rd, Register rs, Register rt)
            : base("and", rd, rs, rt)
        {

        }
    }

    public sealed class OrInstruction : RegisterInstruction
    {
        public OrInstruction(Register rd, Register rs, Register rt)
            : base("or", rd, rs, rt)
        {

        }
    }

    public sealed class XorInstruction : RegisterInstruction
    {
        public XorInstruction(Register rd, Register rs, Register rt)
            : base("xor", rd, rs, rt)
        {

        }
    }

    public sealed class NorInstruction : RegisterInstruction
    {
        public NorInstruction(Register rd, Register rs, Register rt)
            : base("nor", rd, rs, rt)
        {

        }
    }

    #endregion

    #region Load\store instructions

    public sealed class LbInstruction : LoadStoreInstruction
    {
        public LbInstruction(Register rt, short offset, Register @base)
            : base("lb", rt, offset, @base)
        {

        }
    }

    public sealed class LbuInstruction : LoadStoreInstruction
    {
        public LbuInstruction(Register rt, short offset, Register @base)
            : base("lbu", rt, offset, @base)
        {

        }
    }

    public sealed class LhInstruction : LoadStoreInstruction
    {
        public LhInstruction(Register rt, short offset, Register @base)
            : base("lh", rt, offset, @base)
        {

        }
    }

    public sealed class LhuInstruction : LoadStoreInstruction
    {
        public LhuInstruction(Register rt, short offset, Register @base)
            : base("lhu", rt, offset, @base)
        {

        }
    }

    public sealed class LwInstruction : LoadStoreInstruction
    {
        public LwInstruction(Register rt, short offset, Register @base)
            : base("lw", rt, offset, @base)
        {

        }
    }

    public sealed class LwlInstruction : LoadStoreInstruction
    {
        public LwlInstruction(Register rt, short offset, Register @base)
            : base("lwl", rt, offset, @base)
        {

        }
    }

    public sealed class LwrInstruction : LoadStoreInstruction
    {
        public LwrInstruction(Register rt, short offset, Register @base)
            : base("lwr", rt, offset, @base)
        {

        }
    }

    public sealed class SbInstruction : LoadStoreInstruction
    {
        public SbInstruction(Register rt, short offset, Register @base)
            : base("sb", rt, offset, @base)
        {

        }
    }

    public sealed class ShInstruction : LoadStoreInstruction
    {
        public ShInstruction(Register rt, short offset, Register @base)
            : base("sh", rt, offset, @base)
        {

        }
    }

    public sealed class SwInstruction : LoadStoreInstruction
    {
        public SwInstruction(Register rt, short offset, Register @base)
            : base("sw", rt, offset, @base)
        {

        }
    }

    public sealed class SwlInstruction : LoadStoreInstruction
    {
        public SwlInstruction(Register rt, short offset, Register @base)
            : base("swl", rt, offset, @base)
        {

        }
    }

    public sealed class SwrInstruction : LoadStoreInstruction
    {
        public SwrInstruction(Register rt, short offset, Register @base)
            : base("swr", rt, offset, @base)
        {

        }
    }

    #endregion

    #region Immediate shift instructions

    public sealed class SllInstruction : ImmediateShiftInstruction
    {
        public SllInstruction(Register rt, Register rs, short immediate)
            : base("sll", rt, rs, immediate)
        {

        }
    }

    public sealed class SrlInstruction : ImmediateShiftInstruction
    {
        public SrlInstruction(Register rt, Register rs, short immediate)
            : base("srl", rt, rs, immediate)
        {

        }
    }

    public sealed class SraInstruction : ImmediateShiftInstruction
    {
        public SraInstruction(Register rt, Register rs, short immediate)
            : base("sra", rt, rs, immediate)
        {

        }
    }

    #endregion

    #region Register shift instructions

    public sealed class SllvInstruction : RegisterShiftInstruction
    {
        public SllvInstruction(Register rd, Register rs, Register rt)
            : base("sllv", rd, rs, rt)
        {

        }
    }

    public sealed class SrlvInstruction : RegisterShiftInstruction
    {
        public SrlvInstruction(Register rd, Register rs, Register rt)
            : base("srlv", rd, rs, rt)
        {

        }
    }

    public sealed class SravInstruction : RegisterShiftInstruction
    {
        public SravInstruction(Register rd, Register rs, Register rt)
            : base("srav", rd, rs, rt)
        {

        }
    }

    #endregion

    #region Mult\div instructions

    public sealed class MultInstruction : MultDivInstruction
    {
        public MultInstruction(Register rs, Register rt)
            : base("mult", rs, rt)
        {

        }
    }

    public sealed class MultuInstruction : MultDivInstruction
    {
        public MultuInstruction(Register rs, Register rt)
            : base("multu", rs, rt)
        {

        }
    }

    public sealed class DivInstruction : MultDivInstruction
    {
        public DivInstruction(Register rs, Register rt)
            : base("div", rs, rt)
        {

        }
    }

    public sealed class DivuInstruction : MultDivInstruction
    {
        public DivuInstruction(Register rs, Register rt)
            : base("divu", rs, rt)
        {

        }
    }

    #endregion

    #region Mult\div move instructions

    public sealed class MfhiInstruction : MultDivMoveInstruction
    {
        public MfhiInstruction(Register rd)
            : base("mfhi", rd)
        {

        }
    }

    public sealed class MfloInstruction : MultDivMoveInstruction
    {
        public MfloInstruction(Register rd)
            : base("mflo", rd)
        {

        }
    }

    public sealed class MthiInstruction : MultDivMoveInstruction
    {
        public MthiInstruction(Register rd)
            : base("mthi", rd)
        {

        }
    }

    public sealed class MtloInstruction : MultDivMoveInstruction
    {
        public MtloInstruction(Register rd)
            : base("mtlo", rd)
        {

        }
    }

    #endregion

    #region Jump target instructions

    public sealed class JInstruction : JumpTargetInstruction
    {
        public JInstruction(int target)
            : base("j", target)
        {

        }
    }

    public sealed class JalInstruction : JumpTargetInstruction
    {
        public JalInstruction(int target)
            : base("jal", target)
        {

        }
    }

    #endregion

    public sealed class JrInstruction : Instruction
    {
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

    public sealed class JalrInstruction : Instruction
    {
        private Register rs;
        private Register rd;

        public JalrInstruction(Register rs, Register rd)
            : base("jalr")
        {
            this.rs = rs;
            this.rd = rd;
        }

        public override string ToString()
        {
            return string.Format("{1}\t{2}, {3}", name, rs, rd);
        }
    }

    #region Branch register instruction

    public sealed class BeqInstruction : BranchRegisterInstruction
    {
        public BeqInstruction(Register rs, Register rt, int offset)
            : base("beq", rs, rt, offset)
        {

        }
    }

    public sealed class BneInstruction : BranchRegisterInstruction
    {
        public BneInstruction(Register rs, Register rt, int offset)
            : base("bne", rs, rt, offset)
        {

        }
    }

    #endregion

    #region Branch instructions

    public sealed class BlezInstruction : BranchInstruction
    {
        public BlezInstruction(Register rs, int offset)
            : base("blez", rs, offset)
        {

        }
    }

    public sealed class BgtzInstruction : BranchInstruction
    {
        public BgtzInstruction(Register rs, int offset)
            : base("bgtz", rs, offset)
        {

        }
    }

    public sealed class BltzInstruction : BranchInstruction
    {
        public BltzInstruction(Register rs, int offset)
            : base("bltz", rs, offset)
        {

        }
    }

    public sealed class BgezInstruction : BranchInstruction
    {
        public BgezInstruction(Register rs, int offset)
            : base("bgez", rs, offset)
        {

        }
    }

    public sealed class BltzalInstruction : BranchInstruction
    {
        public BltzalInstruction(Register rs, int offset)
            : base("bltzal", rs, offset)
        {

        }
    }

    public sealed class BgezalInstruction : BranchInstruction
    {
        public BgezalInstruction(Register rs, int offset)
            : base("bgezal", rs, offset)
        {

        }
    }

    #endregion

    public sealed class SyscallInstruction : ExceptionInstruction
    {
        public SyscallInstruction(int code)
            : base("syscall", code)
        {

        }
    }

    public sealed class BreakInstruction : ExceptionInstruction
    {
        public BreakInstruction(int code)
            : base("break", code)
        {

        }
    }
}
