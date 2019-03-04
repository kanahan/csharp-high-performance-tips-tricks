using System;
using System.Data;
using System.Runtime.Caching;
using Benchmarking;

namespace Test23
{
    class Program
    {
        static string Path = @"..\..\Data.XML";
        static string Key = "Data";

        static DataSet NoCache()
        {
            DataSet ds = new DataSet();
            ds.ReadXml(Path);
            return ds;
        }

        static DataSet WithCache()
        {
            ObjectCache cache = MemoryCache.Default;
            DataSet ds = cache[Key] as DataSet;
            if (ds == null)
            {
                ds = new DataSet();
                ds.ReadXml(Path);
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(1);
                cache.Add(Key, ds, policy);
            }
            return ds;
        }
        static void Main(string[] args)
        {
            const uint NoOfIteration = 1_000;
            int n;

            Profiler.Profile("No Cache", NoOfIteration, () =>
            {
                DataSet ds = NoCache();
            }, out n);
            Console.WriteLine("No of GC Activation is {0} ", n);

            Profiler.Profile("With Cache", NoOfIteration, () =>
            {
                DataSet ds = WithCache();
            }, out n);
            Console.WriteLine("No of GC Activation is {0} ", n);
        }
    }
}
