using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Serialization.Bench
{
    public class RunResult
    {
        public TimeSpan TotalTime { get; set; }
        public TimeSpan Serialization { get; set; }
        public TimeSpan Deserialization { get; set; }

        public override string ToString()
        {
            return string.Format("S:{0} D:{1} T:{2}", Serialization, Deserialization, TotalTime);
        }
    }
}
