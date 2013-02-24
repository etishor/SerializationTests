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
    public class PublicReadOnlyNamesNotInConstructorWithPrivateParameterlessConstructor : IAssertEquality
    {
        [DataMember]
        [ProtoMember(1)]
        public readonly int IntValue;

        public PublicReadOnlyNamesNotInConstructorWithPrivateParameterlessConstructor(int otherIntValue)
        {
            this.IntValue = otherIntValue;
        }

        public static PublicReadOnlyNamesNotInConstructorWithPrivateParameterlessConstructor CreateInstance()
        {
            return new PublicReadOnlyNamesNotInConstructorWithPrivateParameterlessConstructor(10);
        }

        public void AssertEquality(object other)
        {
            Assert.IsNotNull(other);
            Assert.IsInstanceOfType<PublicReadOnlyNamesNotInConstructorWithPrivateParameterlessConstructor>(other);

            PublicReadOnlyNamesNotInConstructorWithPrivateParameterlessConstructor target = other as PublicReadOnlyNamesNotInConstructorWithPrivateParameterlessConstructor;

            Assert.AreEqual(this.IntValue, target.IntValue);
        }
    }
}
