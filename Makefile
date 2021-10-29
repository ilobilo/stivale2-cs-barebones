KERNELDIR := $(shell dirname $(realpath $(firstword $(MAKEFILE_LIST))))

all: /bin/csc limine
	@mkdir -p $(KERNELDIR)/iso_root
	@$(MAKE) -s -C $(KERNELDIR)/source

bios: /bin/csc limine
	@mkdir -p $(KERNELDIR)/iso_root
	@$(MAKE) -s -C $(KERNELDIR)/source bios

/bin/csc:
	@cp $(KERNELDIR)/ext/csc /bin/

limine:
	@git clone https://github.com/limine-bootloader/limine.git --single-branch --branch=latest-binary --depth=1
	@$(MAKE) -C $(KERNELDIR)/limine

clean:
	@$(MAKE) -s -C $(KERNELDIR)/source clean

distclean:
	@$(MAKE) -s -C $(KERNELDIR)/source clean
	@rm -rf $(KERNELDIR)/limine
	@rm -rf $(KERNELDIR)/iso_root