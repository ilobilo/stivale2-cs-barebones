[EXTERN _ZN6kernel6Kernel7ProgramM_0_8RealMain_Rv_P1PV26stivale2#2Bstivale2_struct]

section .data
stivale2_smp_tag:
    dq 0x1ab015085f3273df
    dq 0
    dq 0

stivale2_any_video_tag:
    dq 0xc75c9fa92a44c4db
    dq stivale2_smp_tag
    dq 1

[SECTION .bss]
align 16
stack_bottom:
resb 8192
stack_top:

[SECTION .stivale2hdr]
align 4
stivale_hdr:
    dq kmain
    dq stack_top
    dq (1 << 1)
    dq stivale2_any_video_tag

[SECTION .text]
kmain:
    push rdi
    call _ZN6kernel6Kernel7ProgramM_0_8RealMain_Rv_P1PV26stivale2#2Bstivale2_struct

sthrow:
    hlt
    jmp sthrow
[GLOBAL sthrow]

_ZN6kernel6Kernel7ProgramM_0_4halt_Rv_P0:
    hlt
    jmp _ZN6kernel6Kernel7ProgramM_0_4halt_Rv_P0
[GLOBAL _ZN6kernel6Kernel7ProgramM_0_4halt_Rv_P0]