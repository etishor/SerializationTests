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
    public class UriField : IAssertEquality
    {
        [DataMember]
        [ProtoMember(1)]
        public Uri Value;

        public static UriField CreateInstance()
        {
            return new UriField { Value = new Uri("http://uri/") };
        }

        public void AssertEquality(object other)
        {
            Assert.IsNotNull(other);
            Assert.IsInstanceOfType<UriField>(other);
            UriField target = other as UriField;

            Assert.AreEqual(this.Value, target.Value);
        }
    }
}
