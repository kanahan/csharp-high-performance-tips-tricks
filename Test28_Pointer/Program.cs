using Benchmarking;
using System;
using System.Reflection.Emit;

namespace Test28
{
    unsafe class Program
    {
        public delegate void MemCpyFunction(void* des, void* src, uint n);

        private static readonly MemCpyFunction memcpy;

        static Program()
        {
            var dynamicMethod = new DynamicMethod("memcpy", typeof(void),
                new[] { typeof(void*), typeof(void*), typeof(uint) }, typeof(Program));
            var ilGenerator = dynamicMethod.GetILGenerator();
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.Emit(OpCodes.Ldarg_1);
            ilGenerator.Emit(OpCodes.Ldarg_2);
            ilGenerator.Emit(OpCodes.Cpblk);
            ilGenerator.Emit(OpCodes.Ret);
            memcpy = (MemCpyFunction)dynamicMethod.CreateDelegate(typeof(MemCpyFunction));
        }

        static void Main(string[] args)
        {
            const int ARRAY_SIZE = 5_000_000;
            int[] Source = new int[ARRAY_SIZE];
            int[] Destination = new int[ARRAY_SIZE];
            for (int i = 0; i < ARRAY_SIZE; i++)
            {
                Source[i] = i;
            }
            const uint NoOfIteration = 1;

            Profiler.Profile("Normal Assignment", NoOfIteration, () =>
            {
                for (int i = 0; i < ARRAY_SIZE; i++)
                {
                    Destination[i] = Source[i];
                }
            });

            Profiler.Profile("Use pointer", NoOfIteration, () =>
            {
                fixed (int* ps = &Source[0], pd = &Destination[0])
                {
                    memcpy(pd, ps, sizeof(int) * ARRAY_SIZE);
                }
            });
        }
    }
}