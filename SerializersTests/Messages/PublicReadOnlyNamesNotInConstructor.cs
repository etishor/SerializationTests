using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using System.Runtime.Serialization;
using ProtoBuf;

namespace SerializersTests
{
    [Serializable]
    [DataContract]
    [ProtoContract]
    public class PublicReadOnlyNamesNotInConstructor : IAssertEquality
    {
        [DataMember]
        [ProtoMember(1)]
        public readonly int IntValue;

        public PublicReadOnlyNamesNotInConstructor(int otherIntValue)
        {
            this.IntValue = otherIntValue;
        }

        public static PublicReadOnlyNamesNotInConstructor CreateInstance()
        {
            return new PublicReadOnlyNamesNotInConstructor(10);
        }

        public void AssertEquality(object other)
        {
            Assert.IsNotNull(other);
            Assert.IsInstanceOfType<PublicReadOnlyNamesNotInConstructor>(other);

            PublicReadOnlyNamesNotInConstructor target = other as PublicReadOnlyNamesNotInConstructor;

            Assert.AreEqual(this.IntValue, target.IntValue);
        }
    }
}
