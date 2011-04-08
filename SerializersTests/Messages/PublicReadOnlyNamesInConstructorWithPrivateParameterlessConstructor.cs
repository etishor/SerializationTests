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
    public class PublicReadOnlyNamesInConstructorWithPrivateParameterlessConstructor : IAssertEquality
    {
        [DataMember]
        [ProtoMember(1)]
        public readonly int IntValue;

        private PublicReadOnlyNamesInConstructorWithPrivateParameterlessConstructor() {}

        public PublicReadOnlyNamesInConstructorWithPrivateParameterlessConstructor(int intValue)
        {
            this.IntValue = intValue;
        }

        public static PublicReadOnlyNamesInConstructorWithPrivateParameterlessConstructor CreateInstance()
        {
            return new PublicReadOnlyNamesInConstructorWithPrivateParameterlessConstructor(10);
        }

        public void AssertEquality(object other)
        {
            Assert.IsNotNull(other);
            Assert.IsInstanceOfType<PublicReadOnlyNamesInConstructorWithPrivateParameterlessConstructor>(other);

            PublicReadOnlyNamesInConstructorWithPrivateParameterlessConstructor target = other as PublicReadOnlyNamesInConstructorWithPrivateParameterlessConstructor;

            Assert.AreEqual(this.IntValue, target.IntValue);            
        }
    }
}
