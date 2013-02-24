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
    public sealed class SealedPublicReadOnlyNamesInConstructorWithPrivateParameterlessConstructor : IAssertEquality
    {
        [DataMember]
        [ProtoMember(1)]
        public readonly int IntValue;

        private SealedPublicReadOnlyNamesInConstructorWithPrivateParameterlessConstructor() {}

        public SealedPublicReadOnlyNamesInConstructorWithPrivateParameterlessConstructor(int intValue)
        {
            this.IntValue = intValue;
        }

        public static SealedPublicReadOnlyNamesInConstructorWithPrivateParameterlessConstructor CreateInstance()
        {
            return new SealedPublicReadOnlyNamesInConstructorWithPrivateParameterlessConstructor(10);
        }

        public void AssertEquality(object other)
        {
            Assert.IsNotNull(other);
            Assert.IsInstanceOfType<SealedPublicReadOnlyNamesInConstructorWithPrivateParameterlessConstructor>(other);

            SealedPublicReadOnlyNamesInConstructorWithPrivateParameterlessConstructor target = other as SealedPublicReadOnlyNamesInConstructorWithPrivateParameterlessConstructor;

            Assert.AreEqual(this.IntValue, target.IntValue);            
        }
    }
}
