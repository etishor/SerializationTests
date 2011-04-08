using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using ProtoBuf;
using MbUnit.Framework;

namespace SerializersTests.Messages
{
    [Serializable]
    [DataContract]
    [ProtoContract]
    public class PrimitiveTypes : IAssertEquality
    {
        [DataMember]
        [ProtoMember(1)]
        public int IntValue;

        [DataMember]
        [ProtoMember(2)]
        public decimal DecimalValue;

        [DataMember]
        [ProtoMember(3)]
        public DateTime DateValue;

        [DataMember]
        [ProtoMember(4)]
        public TimeSpan TimeSpanValue;

        [DataMember]
        [ProtoMember(5)]
        public Guid GuidValue;

        [DataMember]
        [ProtoMember(7)]
        public string StringValue;

        [DataMember]
        [ProtoMember(8)]
        public long LongValue;

        [DataMember]
        [ProtoMember(9)]
        public double DoubleValue;

        public static PrimitiveTypes CreateInstance()
        {
            return new PrimitiveTypes
            {
                IntValue = 10,
                DecimalValue = 10.1m,
                DateValue = DateTime.Now,
                TimeSpanValue = TimeSpan.FromSeconds(20),
                GuidValue = Guid.NewGuid(),
                StringValue = "string",
                LongValue = long.MaxValue,
                DoubleValue = 1654651.13165D
            };
        }

        public void AssertEquality(object other)
        {
            Assert.IsNotNull(other);
            Assert.IsInstanceOfType<PrimitiveTypes>(other);

            PrimitiveTypes target = other as PrimitiveTypes;

            Assert.AreEqual(this.IntValue, target.IntValue);
            Assert.AreEqual(this.DecimalValue, target.DecimalValue);
            Assert.AreApproximatelyEqual(this.DateValue, target.DateValue, TimeSpan.FromMilliseconds(1));
            Assert.AreEqual(this.TimeSpanValue, target.TimeSpanValue);
            Assert.AreEqual(this.GuidValue, target.GuidValue);
            Assert.AreEqual(this.StringValue, target.StringValue);
            Assert.AreEqual(this.LongValue, target.LongValue);
            Assert.AreEqual(Math.Round(this.DoubleValue, 6), Math.Round(target.DoubleValue, 6));
        }

       
    }
}
