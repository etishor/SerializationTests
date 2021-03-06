﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MbUnit.Framework;
using ProtoBuf;

namespace SerializersTests.Messages
{
    [Serializable]
    [DataContract]
    [ProtoContract]
    public class ComposedIDictionaryProperty : IAssertEquality
    {
        [DataMember]
        [ProtoMember(1)]
        public IDictionary<int, List<string>> Value { get; set; }

        public static ComposedIDictionaryProperty CreateInstance()
        {
            return new ComposedIDictionaryProperty { Value = new Dictionary<int, List<string>> { { 10, new List<string> { "a" } } } };
        }

        public void AssertEquality(object other)
        {
            Assert.IsNotNull(other);
            Assert.IsInstanceOfType<ComposedIDictionaryProperty>(other);
            ComposedIDictionaryProperty target = other as ComposedIDictionaryProperty;
            Assert.IsNotNull(target.Value);
            Assert.AreEqual(this.Value.Count, target.Value.Count);
            foreach (var kvp in this.Value)
            {
                var first = kvp.Value;
                var second = target.Value[kvp.Key];
                Assert.AreElementsEqual(first, second);
            }
        }
    }
}
