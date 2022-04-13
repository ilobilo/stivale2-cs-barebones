using System.Runtime.CompilerServices;

namespace Kernel
{
    // Class is unsafe so we can use pointers
    public unsafe class Program
    {
        // Fake kernel entry point
        // Do not remove
        public static void Main()
        {
            // This line is required
            // Without it compiler will remove RealMain from kernel
            RealMain(null);
        }

        public static stivale2.stivale2_struct_tag_smp *smp_tag;

        [MethodImpl(MethodImplOptions.InternalCall)]
        public static extern void halt();

        // Real entry
        public static void RealMain(stivale2.stivale2_struct* stiv)
        {
            // If Stivale2 struct was not found halt
            if (stiv == null) halt();

            // Example on how to get Stivale2 structure tags
            smp_tag = (stivale2.stivale2_struct_tag_smp*)stivale2.get_tag(stiv, stivale2.STIVALE2_STRUCT_TAG_SMP_ID);

            // Print text
            Console.WriteLine("Hello, World!");

            // Halt
            halt();
        }
    }
}
