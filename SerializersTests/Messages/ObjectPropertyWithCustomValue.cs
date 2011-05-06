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
    public class ObjectPropertyWithCustomValue : IAssertEquality
    {
        [DataMember]
        [ProtoMember(1)]
        private object Value {get;set;}

        public static ObjectPropertyWithCustomValue CreateInstance()
        {
            //return new ObjectPropertyWithCustomValue { Value = new CustomObject() { Value = 10 } };
            return new ObjectPropertyWithCustomValue { Value = new Dictionary<int, List<string>> { } };
        }

        public void AssertEquality(object other)
        {
            Assert.IsNotNull(other);
            Assert.IsInstanceOfType<ObjectPropertyWithCustomValue>(other);
            ObjectPropertyWithCustomValue target = other as ObjectPropertyWithCustomValue;

            Assert.IsInstanceOfType(this.Value.GetType(), target.Value);
            //Assert.AreEqual(((CustomObject)this.Value).Value, ((CustomObject)target.Value).Value);
        }
    }
}
