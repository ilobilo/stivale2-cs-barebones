global sthrow

; C# entry point
extern _ZN6kernel6Kernel7ProgramM_0_8RealMain_Rv_P1PV26stivale2#2Bstivale2_struct

section .data

stivale2_smp_tag:
    dq 0x1ab015085f3273df
    dq 0
    dq 0

; Framebuffer
stivale2_framebuffer_tag:
    dq 0x3ecc1bc43d0f7971
    dq stivale2_smp_tag
    dw 0
    dw 0
    dw 32

; Text mode
stivale2_any_video_tag:
    dq 0xc75c9fa92a44c4db
    dq stivale2_smp_tag
    dq 1

; Kernel stack
section .bss
align 16
stack_bottom:
resb 8192
stack_top:

; Stivale2 header
section .stivale2hdr
align 4
stivale_hdr:
    dq kmain
    dq stack_top
    dq (1 << 1)
    ; Replace this with "dq stivale2_framebuffer_tag" to enable framebuffer
    dq stivale2_any_video_tag

section .text
kmain:
    push rdi
    call _ZN6kernel6Kernel7ProgramM_0_8RealMain_Rv_P1PV26stivale2#2Bstivale2_struct

sthrow:
    hlt
    jmp sthrow