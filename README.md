# Stivale2 C# Barebones
Barebones C# kernel using Limine and Stivale2 as bootloader and boot protocol

## Install CSC on linux
1. Download and install dotnet 5</br>
2. Make sure $DOTNET_ROOT is set to correct path (should be directory where dotnet is installed)
3. Copy csc from ext/ directory of this repo to /bin/

## Building
You need these programs installed to build and run the kernel:
* csc
* xorriso
* ld.lld
* nasm
* qemu-system-x86
* tysila2 (deb package included in source)
* mono (to run tysila2)
</br>

Run ```make``` or ```make bios``` to build and run</br>
