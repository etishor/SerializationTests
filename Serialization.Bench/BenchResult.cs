
using System.Collections.Generic;
using System.Linq;
using System;

namespace Serialization.Bench
{
    public class BenchResult
    {
        public BenchResult( string serializer, string objectName )
        {
            this.Serializer = serializer;
            this.InstanceType = objectName;
            this.Results = new List<RunResult>();
        }

        public string Serializer { get; set; }
        public string InstanceType { get; set; }

        public RunResult Warmup { get; set; }

        public List<RunResult> Results { get; private set; }

        public RunResult Average
        {
            get
            {
                RunResult result = new RunResult();

                result.Serialization = TimeSpan.FromTicks((long)Math.Round(Results.Average(r => r.Serialization.Ticks)));
                result.Deserialization = TimeSpan.FromTicks((long)Math.Round(Results.Average(r => r.Deserialization.Ticks)));
                result.TotalTime = TimeSpan.FromTicks((long)Math.Round(Results.Average(r => r.TotalTime.Ticks)));

                return result;
            }
        }
    }

}
