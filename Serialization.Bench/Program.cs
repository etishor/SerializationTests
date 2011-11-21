using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using SerializersTests;
using SerializersTests.Messages;
using System.Text;
using System.Reflection;
using Newtonsoft.Json.Serialization;

namespace Serialization.Bench
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.AssemblyResolve += (s, o) =>
            {
                var name = new AssemblyName(o.Name);
                if (name.Name.Contains("Newtonsoft.Json"))
                {
                    return typeof(JsonContract).Assembly;
                }
                return null;
            };

            SerializationBenchmark.Run();

            Console.WriteLine("Done");
            Console.ReadKey();
        }

        
    }
}
