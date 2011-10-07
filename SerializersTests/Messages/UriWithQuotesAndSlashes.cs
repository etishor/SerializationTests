
namespace SerializersTests.Messages
{
    using System;
    using System.Runtime.Serialization;
    using MbUnit.Framework;
    using ProtoBuf;

    [Serializable]
    [DataContract]
    [ProtoContract]
    public class UriWithQuotesAndSlashes : IAssertEquality
    {
        [DataMember]
        [ProtoMember(1)]
        public Uri ValueWithQuotes { get; set; }

        [DataMember]
        [ProtoMember(2)]
        public Uri ValueWithSlashes { get; set; }

        public static UriWithQuotesAndSlashes CreateInstance()
        {
            return new UriWithQuotesAndSlashes
            {
                ValueWithQuotes = new Uri("http://test.com/%22foo+bar%22"),
                ValueWithSlashes = new Uri(@"http://tes/?a=b\\c&d=e\")
            };
        }

        public void AssertEquality(object other)
        {
            Assert.IsNotNull(other);
            Assert.IsInstanceOfType<UriWithQuotesAndSlashes>(other);
            UriWithQuotesAndSlashes target = other as UriWithQuotesAndSlashes;

            Assert.AreEqual(this.ValueWithQuotes.ToString(), target.ValueWithQuotes.ToString());
            Assert.AreEqual(this.ValueWithSlashes.ToString(), target.ValueWithSlashes.ToString());
        }
    }
}
