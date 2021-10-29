SOURCEDIR := $(shell dirname $(realpath $(firstword $(MAKEFILE_LIST))))

KERNEL := $(SOURCEDIR)/kernel.elf
KERNELEXE := $(KERNEL:.elf=.exe)
KERNELO := $(KERNEL:.elf=.o)
ISO = $(SOURCEDIR)/../image.iso

LIMINE = $(SOURCEDIR)/../limine/limine-install

QEMU = qemu-system-x86_64
QEMUFLAGS = -enable-kvm -M q35 -cpu max -smp 2 -m 512M -boot d -rtc base=localtime -serial stdio

XORRISO = xorriso
XORRISOFLAGS = -as mkisofs -b limine-cd.bin \
		-no-emul-boot -boot-load-size 4 -boot-info-table \
		--efi-boot limine-eltorito-efi.bin -efi-boot-part \
		--efi-boot-image --protective-msdos-label

LD = ld.lld
AS = nasm
AOT = tysila2
CSC = csc

ASMFLAGS = -f elf64
AOTFLAGS = --arch x86_64-elf64-tysos -fno-rtti -fno-exceptions
CSCFLAGS = -unsafe -target:exe -platform:x86 -nostdlib /r:$(SOURCEDIR)/mscorlib.dll

LDFLAGS = -T $(SOURCEDIR)/linker.ld -m elf_x86_64 -z max-page-size=0x1000

CSFILES = $(shell find $(SOURCEDIR)/ -type f -name '*.cs')
ASMFILES = $(shell find $(SOURCEDIR)/ -type f -name '*.asm')
OBJ = $(ASMFILES:.asm=_asm.o)

.PHONY: all
all: $(KERNEL)
	$(MAKE) iso
	$(MAKE) clean run

bios: $(KERNEL)
	$(MAKE) iso
	$(MAKE) clean run-bios

$(KERNEL): $(OBJ)
	$(CSC) $(CSCFLAGS) $(CSFILES) -out:$(KERNELEXE)
	$(AOT) $(AOTFLAGS) $(KERNELEXE) -o $(KERNELO)
	$(LD) $(LDFLAGS) $(INTERNALLDFLAGS) $(OBJ) $(KERNELO) -o $@

%_asm.o: %.asm
	$(AS) $(ASMFLAGS) $^ -o $@

iso:
	cp $(KERNEL) $(SOURCEDIR)/../limine.cfg $(SOURCEDIR)/../limine/limine.sys \
		$(SOURCEDIR)/../limine/limine-cd.bin $(SOURCEDIR)/../limine/limine-eltorito-efi.bin $(SOURCEDIR)/../iso_root/
	$(XORRISO) $(XORRISOFLAGS) $(SOURCEDIR)/../iso_root -o $(ISO)
	$(LIMINE) $(ISO)

clean:
ifndef NOCLEAN
	rm -rf $(KERNEL) $(OBJ) $(KERNELEXE) $(KERNELO) $(SOURCEDIR)/../iso_root/*
endif

run:
	$(QEMU) $(QEMUFLAGS) -cdrom $(ISO) -drive if=pflash,format=raw,unit=0,file=$(SOURCEDIR)/../ovmf/OVMF_CODE-pure-efi.fd,readonly=on -drive if=pflash,format=raw,unit=1,file=$(SOURCEDIR)/../ovmf/OVMF_VARS-pure-efi.fd

run-bios:
	$(QEMU) $(QEMUFLAGS) -cdrom $(ISO)