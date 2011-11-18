
using System;
using System.Diagnostics;
using System.IO;
using SerializersTests;
namespace Serialization.Bench
{
    public static class TestRunner
    {
        public static RunResult TestRun<T>(ISerializerAdapter serializer, T instance)
            where T : IAssertEquality
        {
            RunResult result = new RunResult();

            var w = Stopwatch.StartNew();

            byte[] data;
            T output = default(T);
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    var serW = Stopwatch.StartNew();
                    serializer.Serialize(new IndisposableStream(ms), instance);
                    result.Serialization = serW.Elapsed;
                    data = ms.ToArray();
                }


                using (MemoryStream ms = new MemoryStream(data))
                {
                    ms.Seek(0, SeekOrigin.Begin);
                    var deserW = Stopwatch.StartNew();
					output = (T)serializer.Deserialize(new IndisposableStream(ms), typeof(T));
                    result.Deserialization = deserW.Elapsed;
                }
                result.TotalTime = w.Elapsed;
                instance.AssertEquality(output);
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
                result.Serialization = TimeSpan.FromSeconds(0);
                result.Deserialization = TimeSpan.FromSeconds(0);
                result.TotalTime = TimeSpan.FromSeconds(0);
            }

            return result;
        }
    }
}
