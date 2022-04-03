using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace Kernel
{
    // Class is unsafe so we can use pointers
    public unsafe class Program
    {
		[MethodImpl(MethodImplOptions.InternalCall)]
		public static unsafe extern void termwrite(ulong address, char *str, ulong length);

        // Fake kernel entry point
        // Do not remove
        public static void Main()
        {
            // These line is required
            // Without it compiler will remove RealMain from kernel
            RealMain(null);
        }

        public static stivale2.stivale2_struct_tag_smp *smp_tag;
        public static stivale2.stivale2_struct_tag_terminal *terminal_tag;

        // Real entry
        public static void RealMain(stivale2.stivale2_struct* stiv)
        {
            // If Stivale2 struct was not found halt
            if (stiv == null) while (true);

            // Example on how to get Stivale2 structure tags
            smp_tag = (stivale2.stivale2_struct_tag_smp*)stivale2.get_tag(stiv, stivale2.STIVALE2_STRUCT_TAG_SMP_ID);
            terminal_tag = (stivale2.stivale2_struct_tag_terminal*)stivale2.get_tag(stiv, stivale2.STIVALE2_STRUCT_TAG_TERMINAL_ID);

            fixed(char* p = "Hello, World!") {
			    termwrite(terminal_tag->term_write, p, 14);
            }

            // Halt
            while (true);
        }
    }
}