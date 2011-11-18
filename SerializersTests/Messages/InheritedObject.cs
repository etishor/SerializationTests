using System;
using System.Runtime.Serialization;
using MbUnit.Framework;
using ProtoBuf;

namespace SerializersTests.Messages
{
	[DataContract]
	[Serializable]
	[ProtoContract]
	public class BaseObject  
	{
		public BaseObject(string field, int property)
		{
			this.baseField = field;
			this.BaseProperty = property;
		}

		[DataMember]
		[ProtoMember(1)]
		private string baseField;

		[DataMember]
		[ProtoMember(2)]
		public int BaseProperty { get; protected set; }

		public void AssertBaseEquality(BaseObject target)
		{
			Assert.AreEqual(this.baseField, target.baseField);
			Assert.AreEqual(this.BaseProperty, target.BaseProperty);
		}
	}

	[DataContract]
	[Serializable]
	[ProtoContract]
	public class InheritedObject  : BaseObject, IAssertEquality
	{
		[DataMember]
		[ProtoMember(3)]
		private Guid field;
		
		public InheritedObject(Guid field, string baseField, int baseProperty)
			:base(baseField,baseProperty)
		{
			this.field = field;
		}

		[DataMember]
		[ProtoMember(4)]
		public Uri Uri { get; set; }


		public static InheritedObject CreateInstance()
		{
			return new InheritedObject(Guid.NewGuid(), "base", 10) { Uri = new Uri("http://www.google.com") };
		}

		public void AssertEquality(object other)
		{
			Assert.IsNotNull(other);
			Assert.IsInstanceOfType<InheritedObject>(other);

			InheritedObject target = other as InheritedObject;

			target.AssertBaseEquality(other as BaseObject);
			
			Assert.AreEqual(this.field, target.field);
			Assert.AreEqual(this.Uri, target.Uri);
		}
	}
}
