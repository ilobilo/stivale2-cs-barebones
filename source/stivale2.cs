using System.Runtime.InteropServices;

namespace Kernel
{
    public unsafe static class stivale2
    {
        public static void *get_tag(stivale2_struct *stivale, ulong id)
        {
            stivale2_tag *current_tag = (stivale2_tag*)stivale->tags;
            while (true)
            {
                if (current_tag == null) return null;

                if (current_tag->identifier == id) return current_tag;

                current_tag = (stivale2_tag*)current_tag->next;
            }
            return null;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct stivale2_anchor
        {
            public fixed byte anchor[15];
            public byte bits;
            public ulong phys_load_addr;
            public ulong phys_bss_start;
            public ulong phys_bss_end;
            public ulong phys_stivale2hdr;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct stivale2_tag
        {
            public ulong identifier;
            public ulong next;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct stivale2_header
        {
            public ulong entry_point;
            public ulong stack;
            public ulong flags;
            public ulong tags;
        }

        public static ulong STIVALE2_HEADER_TAG_ANY_VIDEO_ID = 0xc75c9fa92a44c4db;

        [StructLayout(LayoutKind.Sequential)]
        public struct stivale2_header_tag_any_video
        {
            public stivale2_tag tag;
            public ulong preference;
        }

        public static ulong STIVALE2_HEADER_TAG_FRAMEBUFFER_ID = 0x3ecc1bc43d0f7971;

        [StructLayout(LayoutKind.Sequential)]
        public struct stivale2_header_tag_framebuffer
        {
            public stivale2_tag tag;
            public ushort framebuffer_width;
            public ushort framebuffer_height;
            public ushort framebuffer_bpp;
            public ushort unused;
        }

        public static ulong STIVALE2_HEADER_TAG_FB_MTRR_ID = 0x4c7bb07731282e00;
        public static ulong STIVALE2_HEADER_TAG_TERMINAL_ID = 0xa85d499b1823be72;

        [StructLayout(LayoutKind.Sequential)]
        public struct stivale2_header_tag_terminal
        {
            public stivale2_tag tag;
            public ulong flags;
            public ulong callback;
        }

        public static ulong STIVALE2_TERM_CB_DEC = 10;
        public static ulong STIVALE2_TERM_CB_BELL = 20;

        public static ulong STIVALE2_HEADER_TAG_SMP_ID = 0x1ab015085f3273df;

        [StructLayout(LayoutKind.Sequential)]
        public struct stivale2_header_tag_smp
        {
            public stivale2_tag tag;
            public ulong flags;
        }

        public static ulong STIVALE2_HEADER_TAG_5LV_PAGING_ID = 0x932f477032007e8f;
        public static ulong STIVALE2_HEADER_TAG_UNMAP_NULL_ID = 0x92919432b16fe7e7;

        public static ulong STIVALE2_BOOTLOADER_BRAND_SIZE = 64;
        public static ulong STIVALE2_BOOTLOADER_VERSION_SIZE = 64;

        [StructLayout(LayoutKind.Sequential)]
        public struct stivale2_struct
        {
            public fixed byte bootloader_brand[64];
            public fixed byte bootloader_version[64];
            public ulong tags;
        }

        public static ulong STIVALE2_STRUCT_TAG_PMRS_ID = 0x5df266a64047b6bd;

        public static ulong STIVALE2_PMR_EXECUTABLE = ((ulong)1 << 0);
        public static ulong STIVALE2_PMR_WRITABLE = ((ulong)1 << 1);
        public static ulong STIVALE2_PMR_READABLE = ((ulong)1 << 2);

        [StructLayout(LayoutKind.Sequential)]
        public struct stivale2_pmr
        {
            public ulong _base;
            public ulong length;
            public ulong permissions;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct stivale2_struct_tag_pmrs
        {
            public stivale2_tag tag;
            public ulong entries;
            public stivale2_pmr* pmrs;
        }

        public static ulong STIVALE2_STRUCT_TAG_CMDLINE_ID = 0xe5e76a1b4597a781;

        [StructLayout(LayoutKind.Sequential)]
        public struct stivale2_struct_tag_cmdline
        {
            public stivale2_tag tag;
            public ulong cmdline;
        }

        public static ulong STIVALE2_STRUCT_TAG_MEMMAP_ID = 0x2187f79e8612de07;

        public static ulong STIVALE2_MMAP_USABLE = 1;
        public static ulong STIVALE2_MMAP_RESERVED = 2;
        public static ulong STIVALE2_MMAP_ACPI_RECLAIMABLE = 3;
        public static ulong STIVALE2_MMAP_ACPI_NVS = 4;
        public static ulong STIVALE2_MMAP_BAD_MEMORY = 5;
        public static ulong STIVALE2_MMAP_BOOTLOADER_RECLAIMABLE = 0x1000;
        public static ulong STIVALE2_MMAP_KERNEL_AND_MODULES = 0x1001;
        public static ulong STIVALE2_MMAP_FRAMEBUFFER = 0x1002;

        [StructLayout(LayoutKind.Sequential)]
        public struct stivale2_mmap_entry
        {
            public ulong _base;
            public ulong length;
            public uint type;
            public uint unused;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct stivale2_struct_tag_memmap
        {
            public stivale2_tag tag;
            public ulong entries;
            public stivale2_mmap_entry* memmap;
        }

        public static ulong STIVALE2_STRUCT_TAG_FRAMEBUFFER_ID = 0x506461d2950408fa;
        public static ulong STIVALE2_FBUF_MMODEL_RGB = 1;

        [StructLayout(LayoutKind.Sequential)]
        public struct stivale2_struct_tag_framebuffer
        {
            public stivale2_tag tag;
            public ulong framebuffer_addr;
            public ushort framebuffer_width;
            public ushort framebuffer_height;
            public ushort framebuffer_pitch;
            public ushort framebuffer_bpp;
            public byte memory_model;
            public byte red_mask_size;
            public byte red_mask_shift;
            public byte green_mask_size;
            public byte green_mask_shift;
            public byte blue_mask_size;
            public byte blue_mask_shift;
            public byte unused;
        }

        public static ulong STIVALE2_STRUCT_TAG_EDID_ID = 0x968609d7af96b845;

        public struct stivale2_struct_tag_edid
        {
            public stivale2_tag tag;
            public ulong edid_size;
            public fixed byte edid_information[64];
        };

        public static ulong STIVALE2_STRUCT_TAG_TEXTMODE_ID = 0x38d74c23e0dca893;

        public struct stivale2_struct_tag_textmode
        {
            public stivale2_tag tag;
            public ulong address;
            public ushort unused;
            public ushort rows;
            public ushort cols;
            public ushort bytes_per_char;
        };

        public static ulong STIVALE2_STRUCT_TAG_FB_MTRR_ID = 0x6bc1a78ebe871172;

        public static ulong STIVALE2_STRUCT_TAG_TERMINAL_ID = 0xc2b3f4c3233b0974;

        public struct stivale2_struct_tag_terminal
        {
            public stivale2_tag tag;
            public uint flags;
            public ushort cols;
            public ushort rows;
            public ulong term_write;
            public ulong max_length;
        };

        public static ulong STIVALE2_STRUCT_TAG_MODULES_ID = 0x4b6fe466aade04ce;

        public static ulong STIVALE2_MODULE_STRING_SIZE = 128;

        public struct stivale2_module
        {
            public ulong begin;
            public ulong end;
            public fixed byte _string[64];
        }

        public struct stivale2_struct_tag_modules
        {
            public stivale2_tag tag;
            public ulong module_count;
            public stivale2_module* modules;
        }

        public static ulong STIVALE2_STRUCT_TAG_RSDP_ID = 0x9e1786930a375e78;

        public struct stivale2_struct_tag_rsdp
        {
            public stivale2_tag tag;
            public ulong rsdp;
        }

        public static ulong STIVALE2_STRUCT_TAG_EPOCH_ID = 0x566a7bed888e1407;

        public struct stivale2_struct_tag_epoch
        {
            public stivale2_tag tag;
            public ulong epoch;
        }

        public static ulong STIVALE2_STRUCT_TAG_FIRMWARE_ID = 0x359d837855e3858c;

        public static ulong STIVALE2_FIRMWARE_BIOS = (1 << 0);

        public struct stivale2_struct_tag_firmware
        {
            public stivale2_tag tag;
            public ulong flags;
        }

        public static ulong STIVALE2_STRUCT_TAG_EFI_SYSTEM_TABLE_ID = 0x4bc5ec15845b558e;

        public struct stivale2_struct_tag_efi_system_table
        {
            public stivale2_tag tag;
            public ulong system_table;
        }

        public static ulong STIVALE2_STRUCT_TAG_KERNEL_FILE_ID = 0xe599d90c2975584a;

        public struct stivale2_struct_tag_kernel_file
        {
            public stivale2_tag tag;
            public ulong kernel_file;
        }

        public static ulong STIVALE2_STRUCT_TAG_KERNEL_FILE_V2_ID = 0x37c13018a02c6ea2;

        public struct stivale2_struct_tag_kernel_file_v2
        {
            public stivale2_tag tag;
            public ulong kernel_file;
            public ulong kernel_size;
        }

        public static ulong STIVALE2_STRUCT_TAG_KERNEL_SLIDE_ID = 0xee80847d01506c57;

        public struct stivale2_struct_tag_kernel_slide
        {
            public stivale2_tag tag;
            public ulong kernel_slide;
        }

        public static ulong STIVALE2_STRUCT_TAG_SMBIOS_ID = 0x274bd246c62bf7d1;

        public struct stivale2_struct_tag_smbios
        {
            public stivale2_tag tag;
            public ulong flags;
            public ulong smbios_entry_32;
            public ulong smbios_entry_64;
        }

        public static ulong STIVALE2_STRUCT_TAG_SMP_ID = 0x34d1d96339647025;

        public struct stivale2_smp_info
        {
            public uint processor_id;
            public uint lapic_id;
            public ulong target_stack;
            public ulong goto_address;
            public ulong extra_argument;
        }

        public struct stivale2_struct_tag_smp
        {
            public stivale2_tag tag;
            public ulong flags;
            public uint bsp_lapic_id;
            public uint unused;
            public ulong cpu_count;
            public stivale2_smp_info* smp_info;
        }

        public static ulong STIVALE2_STRUCT_TAG_PXE_SERVER_INFO = 0x29d1e96239247032;

        public struct stivale2_struct_tag_pxe_server_info
        {
            public stivale2_tag tag;
            public uint server_ip;
        }

        public static ulong STIVALE2_STRUCT_TAG_MMIO32_UART = 0xb813f9b8dbc78797;

        public struct stivale2_struct_tag_mmio32_uart
        {
            public stivale2_tag tag;
            public ulong addr;
        }

        public static ulong STIVALE2_STRUCT_TAG_DTB = 0xabb29bd49a2833fa;

        public struct stivale2_struct_tag_dtb
        {
            public stivale2_tag tag;
            public ulong addr;
            public ulong size;
        }

        public static ulong STIVALE2_STRUCT_TAG_VMAP = 0xb0ed257db18cb58f;

        public struct stivale2_struct_vmap
        {
            public stivale2_tag tag;
            public ulong addr;
        }
    }
}