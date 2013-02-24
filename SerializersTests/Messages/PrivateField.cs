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
    public class PrivateField : IAssertEquality
    {
        [DataMember]
        [ProtoMember(1)]
        private int Value;

        public static PrivateField CreateInstance()
        {
            return new PrivateField { Value = 10 };
        }

        public void AssertEquality(object other)
        {
            Assert.IsNotNull(other);
            Assert.IsInstanceOfType<PrivateField>(other);
            PrivateField target = other as PrivateField;

            Assert.AreEqual(this.Value, target.Value);
        }
    }
}
