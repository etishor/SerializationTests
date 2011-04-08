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
    public class ArrayField : IAssertEquality
    {
        [DataMember]
        [ProtoMember(1)]
        private int[] Value;

        public static ArrayField CreateInstance()
        {
            return new ArrayField { Value = new int[] { 10 , 20 }  };
        }

        public void AssertEquality(object other)
        {
            Assert.IsNotNull(other);
            Assert.IsInstanceOfType<ArrayField>(other);
            ArrayField target = other as ArrayField;

            Assert.AreElementsEqual(this.Value, target.Value);
        }
    }
}
