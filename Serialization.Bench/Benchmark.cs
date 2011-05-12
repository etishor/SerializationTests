using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SerializersTests;

namespace Serialization.Bench
{
    public static class Benchmark
    {
        public static int Times = 10;

        public static BenchResult Run<T>(ISerializerAdapter serializer, T instance)
            where T : IAssertEquality
        {
            BenchResult result = new BenchResult(serializer.GetType().Name, instance.GetType().Name);

            result.Warmup = TestRunner.TestRun(serializer, instance);

            for (int i = 0; i < Times;i++ )
            {
                result.Results.Add(TestRunner.TestRun(serializer, instance));
            }
            
            return result;
        }    
    }
}
