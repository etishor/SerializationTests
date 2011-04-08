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
    public class ArrayProperty : IAssertEquality
    {
        [DataMember]
        [ProtoMember(1)]
        private int[] Value {get;set;}

        public static ArrayProperty CreateInstance()
        {
            return new ArrayProperty { Value = new int[] { 10, 20 } };
        }

        public void AssertEquality(object other)
        {
            Assert.IsNotNull(other);
            Assert.IsInstanceOfType<ArrayProperty>(other);
            ArrayProperty target = other as ArrayProperty;

            Assert.AreElementsEqual(this.Value, target.Value);
        }
    }
}
