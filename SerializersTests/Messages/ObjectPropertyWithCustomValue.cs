using System;
using System.Runtime.Serialization;
using MbUnit.Framework;
using ProtoBuf;

namespace SerializersTests.Messages
{
	[Serializable]
	[DataContract]
	[ProtoContract]
	public class ObjectPropertyWithCustomValue : IAssertEquality
	{
		[DataMember]
		[ProtoMember(1)]
		public object Value {get;set;}

		public static ObjectPropertyWithCustomValue CreateInstance()
		{
			return new ObjectPropertyWithCustomValue { Value = new CustomObject() { Value = 10 } };
		}

		public void AssertEquality(object other)
		{
			Assert.IsNotNull(other);
			Assert.IsInstanceOfType<ObjectPropertyWithCustomValue>(other);
			ObjectPropertyWithCustomValue target = other as ObjectPropertyWithCustomValue;

			CustomObject val = target.Value as CustomObject;
			Assert.IsNotNull(val);
			Assert.AreEqual(((CustomObject)this.Value).Value, val.Value);
		}
	}
}
