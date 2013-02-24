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
    public class CollectionOfStrings : List<string>, IAssertEquality
    {
        public static CollectionOfStrings CreateInstance()
        {
            return new CollectionOfStrings { "test" };
        }

        public void AssertEquality(object other)
        {
            Assert.IsNotNull(other);
            Assert.IsInstanceOfType<CollectionOfStrings>(other);
            CollectionOfStrings target = other as CollectionOfStrings;

            Assert.AreElementsEqual(this, target);
        }
    }
}
