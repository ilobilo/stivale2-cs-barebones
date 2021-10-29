namespace Kernel
{
    // Class is unsafe so we can use pointers
    public unsafe class Program
    {
        // Fake kernel entry point
        // Do not remove
        public static void Main()
        {
            // These lines of code are required
            // Without them compiler will remove RealMain from kernel
            stivale2.stivale2_struct* test = null;
            RealMain(test);
        }

        public static stivale2.stivale2_struct_tag_smp *smp_tag;

        // Real entry
        public static void RealMain(stivale2.stivale2_struct* stiv)
        {
            // If Stivale2 struct was not found halt
            if (stiv == null) while (true);

            // Example on how to get Stivale2 structure tags
            smp_tag = (stivale2.stivale2_struct_tag_smp*)stivale2.get_tag(stiv, stivale2.STIVALE2_STRUCT_TAG_SMP_ID);

            // Print text
            Console.WriteLine("Hello, World!");

            // Halt
            while (true);
        }
    }
}