KERNELDIR := $(shell dirname $(realpath $(firstword $(MAKEFILE_LIST))))

all: limine
	@mkdir -p $(KERNELDIR)/iso_root
	@$(MAKE) -s -C $(KERNELDIR)/source

bios: limine
	@mkdir -p $(KERNELDIR)/iso_root
	@$(MAKE) -s -C $(KERNELDIR)/source bios

limine:
	@git clone https://github.com/limine-bootloader/limine.git --branch=v2.0-branch-binary --depth=1
	@$(MAKE) -C $(KERNELDIR)/limine

clean:
	@$(MAKE) -s -C $(KERNELDIR)/source clean

distclean:
	@$(MAKE) -s -C $(KERNELDIR)/source clean
	@rm -rf $(KERNELDIR)/limine
	@rm -rf $(KERNELDIR)/iso_root
