//Macros library by bsv798
//for ARMIPS assembler v0.7c by Kingcom (http://aerie.wingdreams.net/?page_id=6)


.macro loaddi, dest, source, immediate
	addi	dest, source, immediate & 0xffff
.endmacro

.macro loaddiu, dest, source, immediate
	addiu	dest, source, immediate & 0xffff
.endmacro

.macro loori, dest, source, immediate
	ori	dest, source, immediate & 0xffff
.endmacro

.macro hilui, dest, value
	lui	dest, (value >> 0x10) + ((value & 0x8000) != 0)
.endmacro


.macro lolb, dest, offset, base
	lb	dest, offset & 0xffff (base)
.endmacro

.macro lolh, dest, offset, base
	lh	dest, offset & 0xffff (base)
.endmacro

.macro lolwl, dest, offset, base
	lwl	dest, offset & 0xffff (base)
.endmacro

.macro lolw, dest, offset, base
	lw	dest, offset & 0xffff (base)
.endmacro

.macro lolbu, dest, offset, base
	lbu	dest, offset & 0xffff (base)
.endmacro

.macro lolhu, dest, offset, base
	lhu	dest, offset & 0xffff (base)
.endmacro

.macro lolwr, dest, offset, base
	lwr	dest, offset & 0xffff (base)
.endmacro


.macro losb, dest, offset, base
	sb	dest, offset & 0xffff (base)
.endmacro

.macro losh, dest, offset, base
	sh	dest, offset & 0xffff (base)
.endmacro

.macro loswl, dest, offset, base
	swl	dest, offset & 0xffff (base)
.endmacro

.macro losw, dest, offset, base
	sw	dest, offset & 0xffff (base)
.endmacro

.macro loswr, dest, offset, base
	swr	dest, offset & 0xffff (base)
.endmacro


.macro lolwc0, dest, offset, base
	lwc0	dest, offset & 0xffff (base)
.endmacro

.macro lolwc1, dest, offset, base
	lwc1	dest, offset & 0xffff (base)
.endmacro

.macro lolwc2, dest, offset, base
	lwc2	dest, offset & 0xffff (base)
.endmacro

.macro lolwc3, dest, offset, base
	lwc3	dest, offset & 0xffff (base)
.endmacro


.macro loswc0, dest, offset, base
	swc0	dest, offset & 0xffff (base)
.endmacro

.macro loswc1, dest, offset, base
	swc1	dest, offset & 0xffff (base)
.endmacro

.macro loswc2, dest, offset, base
	swc2	dest, offset & 0xffff (base)
.endmacro

.macro loswc3, dest, offset, base
	swc3	dest, offset & 0xffff (base)
.endmacro
