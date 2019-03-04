using Benchmarking;
using System;
using System.Runtime.InteropServices;

namespace Test29
{
    unsafe class Program
    {
        [DllImport("msvcrt.dll", EntryPoint = "memset", CallingConvention = CallingConvention.Cdecl,
            SetLastError = false)]
        public static extern IntPtr memset(void* dest, int c, int size_t);

        static void Main(string[] args)
        {
            int[] Data = new int[1000];
            const uint NoOfIteration = 1_000_000;

            Profiler.Profile("Conventional Way", NoOfIteration, () =>
            {
                for (int i = 0; i < Data.Length; i++)
                {
                    Data[i] = 0;
                }
            });

            Profiler.Profile("Array.Clear", NoOfIteration, () =>
            {
                Array.Clear(Data, 0, Data.Length);
            });

            Profiler.Profile("memset", NoOfIteration, () =>
            {
                fixed (void* p = &Data[0])
                {
                    memset(p, 0, sizeof(int) * Data.Length);
                }
            });
        }
    }
}