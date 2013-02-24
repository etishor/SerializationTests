using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using System.Runtime.Serialization;
using ProtoBuf;

namespace SerializersTests.Messages
{
    [Serializable]
    [DataContract]
    [ProtoContract]
    public class PublicField : IAssertEquality
    {
        [DataMember]
        [ProtoMember(1)]
        public int Value;

        public static PublicField CreateInstance()
        {
            return new PublicField { Value = 10 };
        }

        public void AssertEquality(object other)
        {
            Assert.IsNotNull(other);
            Assert.IsInstanceOfType<PublicField>(other);
            PublicField target = other as PublicField;

            Assert.AreEqual(this.Value, target.Value);
        }
    }
}
