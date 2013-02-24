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
    public sealed class SealedPublicReadOnlyNamesInConstructor : IAssertEquality
    {
        [DataMember]
        [ProtoMember(1)]
        public readonly int IntValue;

        public SealedPublicReadOnlyNamesInConstructor(int intValue)
        {
            this.IntValue = intValue;
        }

        public static SealedPublicReadOnlyNamesInConstructor CreateInstance()
        {
            return new SealedPublicReadOnlyNamesInConstructor(10);
        }

        public void AssertEquality(object other)
        {
            Assert.IsNotNull(other);
            Assert.IsInstanceOfType<SealedPublicReadOnlyNamesInConstructor>(other);

            SealedPublicReadOnlyNamesInConstructor target = other as SealedPublicReadOnlyNamesInConstructor;

            Assert.AreEqual(this.IntValue, target.IntValue);            
        }
    }
}
