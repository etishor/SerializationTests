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
    public class CollectionOfCustomObjects : List<CustomObject>, IAssertEquality
    {
        public static CollectionOfCustomObjects CreateInstance()
        {
            return new CollectionOfCustomObjects { new CustomObject { Value = 10 } };
        }

        public void AssertEquality(object other)
        {
            Assert.IsNotNull(other);
            Assert.IsInstanceOfType<CollectionOfCustomObjects>(other);
            CollectionOfCustomObjects target = other as CollectionOfCustomObjects;

            Assert.IsInstanceOfType(typeof(CustomObject), target.Single());
            Assert.AreEqual(this.Single().Value, target.Single().Value);
        }
    }
}
