
using SerializersTests;
using System.Diagnostics;
using System.IO;
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
            using (MemoryStream ms = new MemoryStream())
            {
                var serW = Stopwatch.StartNew();
                serializer.Serialize(new IndisposableStream(ms), instance);
                result.Serialization = serW.Elapsed;
                data = ms.ToArray();
            }

            T output = default(T);
            using (MemoryStream ms = new MemoryStream(data))
            {
                ms.Seek(0, SeekOrigin.Begin);
                var deserW = Stopwatch.StartNew();
                output = serializer.Deserialize<T>(new IndisposableStream(ms));
                result.Deserialization = deserW.Elapsed;
            }
            result.TotalTime = w.Elapsed;
            instance.AssertEquality(output);
            return result;
        }
    }
}
