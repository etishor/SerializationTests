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
    public class ObjectProperty : IAssertEquality
    {
        [DataMember]
        [ProtoMember(1)]
        private object Value {get;set;}

        public static ObjectProperty CreateInstance()
        {
            return new ObjectProperty { Value = "test" };
        }

        public void AssertEquality(object other)
        {
            Assert.IsNotNull(other);
            Assert.IsInstanceOfType<ObjectProperty>(other);
            ObjectProperty target = other as ObjectProperty;

            Assert.IsInstanceOfType(this.Value.GetType(), target.Value);
        }
    }
}
