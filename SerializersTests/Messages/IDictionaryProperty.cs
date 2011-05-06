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
    public class IDictionaryProperty : IAssertEquality
    {
        [DataMember]
        [ProtoMember(1)]
        private IDictionary<int,string> Value { get; set; }

        public static IDictionaryProperty CreateInstance()
        {
            return new IDictionaryProperty { Value = new Dictionary<int, string> { { 10, "a" } } };
        }

        public void AssertEquality(object other)
        {
            Assert.IsNotNull(other);
            Assert.IsInstanceOfType<IDictionaryProperty>(other);
            IDictionaryProperty target = other as IDictionaryProperty;

            Assert.AreElementsEqual(this.Value, target.Value);
        }
    }
}
