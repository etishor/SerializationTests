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
            SerializationBenchmark.Run();

            Console.WriteLine("Done");
            Console.ReadKey();
        }

        
    }
}
