using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SerializersTests;
using SerializersTests.Messages;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Serialization.Bench
{
    public static class SerializationBenchmark
    {
        public static void Run()
        {
            var instance = CreateInstance();
            List<BenchResult> results = RunTests(instance);

            WriteToConsole(results);
            WriteToCSVFile(@"results.csv",results);
            WriteCharts(results);            
        }

        private static void WriteCharts(List<BenchResult> results)
        {
            ChartHelper.CreateChart(@"serialization.png", "Serialization Times (ms)", results, r => r.Average.Serialization.TotalMilliseconds);
            ChartHelper.CreateChart(@"deserialization.png", "Deserialization Times (ms)", results, r => r.Average.Deserialization.TotalMilliseconds);
            ChartHelper.CreateChart(@"total.png", "Total Times (ms)", results, r => r.Average.TotalTime.TotalMilliseconds);

            /*
            ChartHelper.CreateChart(@"serialization-min.png", "Min Serialization Times (ms)", results, r => r.Results.Min(rs => rs.Serialization.TotalMilliseconds));
            ChartHelper.CreateChart(@"deserialization-min.png", "Min Deserialization Times (ms)", results, r => r.Results.Min(rs => rs.Deserialization.TotalMilliseconds));
            ChartHelper.CreateChart(@"total-min.png", "Min Total Times (ms)", results, r => r.Results.Min(rs => rs.TotalTime.TotalMilliseconds));

            ChartHelper.CreateChart(@"serialization-max.png", "Max Serialization Times (ms)", results, r => r.Results.Max(rs => rs.Serialization.TotalMilliseconds));
            ChartHelper.CreateChart(@"deserialization-max.png", "Max Deserialization Times (ms)", results, r => r.Results.Max(rs => rs.Deserialization.TotalMilliseconds));
            ChartHelper.CreateChart(@"total-max.png", "Max Total Times (ms)", results, r => r.Results.Max(rs => rs.TotalTime.TotalMilliseconds));
             */
        }

        private static void WriteToCSVFile(string file,List<BenchResult> results)
        {
            StringBuilder b = new StringBuilder();
            b.AppendLine("Serializer,Serialization Time, Deserialization Time, Total Time");

            foreach (var res in results)
            {
                b.AppendLine(string.Format("{0},{1},{2},{3}", res.Serializer,
                    res.Average.Serialization.TotalMilliseconds,
                    res.Average.Deserialization.TotalMilliseconds,
                    res.Average.TotalTime.TotalMilliseconds));

                foreach (var r in res.Results)
                {
                    b.AppendLine(string.Format("{0},{1},{2},{3}", res.Serializer,
                    r.Serialization.TotalMilliseconds,
                    r.Deserialization.TotalMilliseconds,
                    r.TotalTime.TotalMilliseconds));
                }
            }

            File.WriteAllText(file, b.ToString());
        }

        private static void WriteToConsole(List<BenchResult> results)
        {            
            results.ForEach(r => { Console.WriteLine(r.Serializer); Console.WriteLine(r.Average); });
        }

        private static List<BenchResult> RunTests(BenchTestObjectA instance)
        {
            List<BenchResult> results = new List<BenchResult>();
            IEnumerable<ISerializerAdapter> serializers = SerializationTests.GetSerializers()
               .Select(t => (ISerializerAdapter)Activator.CreateInstance(t));

            foreach (var ser in serializers)
            {
                Console.WriteLine("Benchmarking {0}", ser.GetType().Name);
                var result = Benchmark.Run(ser, instance);
                results.Add(result);
            }
            return results.OrderBy(r => r.Average.TotalTime).ToList();
        }

        private static BenchTestObjectA CreateInstance()
        {
            var instance = BenchTestObjectA.CreateInstance();
            BinaryFormatter f = new BinaryFormatter();
            long size;
            using (MemoryStream ms = new MemoryStream())
            {
                f.Serialize(ms, instance);
                size = ms.Length;
            }
            Console.WriteLine("instance created {0} bytes", size);
            return instance;
        }
    
    }
}
