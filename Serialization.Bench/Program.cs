using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using SerializersTests;
using SerializersTests.Messages;
using System.Text;

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
