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

        // Real entry
        public static void RealMain(stivale2.stivale2_struct* stiv)
        {
            // If Stivale2 struct was not found halt
            if (stiv == null) while (true);

            // Print text
            Console.WriteLine("Hello, World!");

            // Halt
            while (true);
        }
    }
}