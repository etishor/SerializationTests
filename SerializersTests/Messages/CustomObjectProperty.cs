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
    public class CustomObject
    {
        [DataMember]
        [ProtoMember(1)]
        public int Value { get; set; }
    }

    [Serializable]
    [DataContract]
    [ProtoContract]
    public class CustomObjectProperty : IAssertEquality
    {
        [DataMember]
        [ProtoMember(1)]
        private CustomObject Value { get; set; }

        public static CustomObjectProperty CreateInstance()
        {
            return new CustomObjectProperty { Value = new CustomObject { Value = 10 } };
        }

        public void AssertEquality(object other)
        {
            Assert.IsNotNull(other);
            Assert.IsInstanceOfType<CustomObjectProperty>(other);
            CustomObjectProperty target = other as CustomObjectProperty;

            Assert.AreNotSame(this.Value, target.Value);
            Assert.IsNotNull(this.Value);
            Assert.IsNotNull(target.Value);
            Assert.AreEqual(this.Value.Value, target.Value.Value);
        }
    }
}
