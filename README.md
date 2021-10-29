# Stivale2 C# Barebones
Barebones C# kernel using Limine and Stivale2 as bootloader and boot protocol

## Install CSC on linux
1. Download and install dotnet 5</br>
2. Make sure dotnet is installed in /usr/share/dotnet/ directory
3. Copy csc from ext/ directory of this repo to /bin/

## Building
You need these programs installed to build and run the kernel:
* csc
* tysila2 (deb package included in source)
* mono (to run tysila2)
* nasm
* ld.lld
* xorriso
* qemu-system-x86

Run ```make``` or ```make bios``` to build and run</br>
