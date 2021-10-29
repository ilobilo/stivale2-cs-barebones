# Stivale2 C# Barebones
Barebones C# kernel using Limine and Stivale2 as bootloader and boot protocol

## Install CSC on linux
1. Download and install dotnet 5</br>
2. Add this line to your ~/.bashrc file:
   ``export DOTNET_ROOT=/usr/share/dotnet/``</br>
   (replace /usr/share/dotnet with path where dotnet was installed)
3. run ``source ~/.bashrc``
4. Copy csc from ext/ directory of this repo to /bin/

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
