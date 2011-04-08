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
    public class PrivateProperty : IAssertEquality
    {
        [DataMember]
        [ProtoMember(1)]
        private int Value { get; set; }

        public static PrivateProperty CreateInstance()
        {
            return new PrivateProperty { Value = 10 };
        }

        public void AssertEquality(object other)
        {
            Assert.IsNotNull(other);
            Assert.IsInstanceOfType<PrivateProperty>(other);
            PrivateProperty target = other as PrivateProperty;

            Assert.AreEqual(this.Value, target.Value);
        }
    }
}
