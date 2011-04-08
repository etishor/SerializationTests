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
    public class PublicSetter : IAssertEquality
    {
        [DataMember]
        [ProtoMember(1)]
        public int IntValue { get; set; }
  
        public static PublicSetter CreateInstance()
        {
            return new PublicSetter { IntValue = 10 };
        }

        public void AssertEquality(object other)
        {
            Assert.IsNotNull(other);
            Assert.IsInstanceOfType<PublicSetter>(other);

            PublicSetter target = other as PublicSetter;

            Assert.AreEqual(this.IntValue, target.IntValue);
        }
    }
}
