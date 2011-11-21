using System;
using MbUnit.Framework;

namespace SerializersTests.Messages
{
	public sealed class PublicReadonlyFieldWithNamesInConstructorNoAttributes : IAssertEquality
	{
		private readonly Guid Id;
		private readonly DateTime Date;
		private readonly string Text;
		private readonly int Number;
		private readonly Uri Uri;

		public PublicReadonlyFieldWithNamesInConstructorNoAttributes(Guid id, DateTime date, string text, int number, Uri uri)
		{
			this.Id = id;
			this.Date = date;
			this.Text = text;
			this.Number = number;
			this.Uri = uri;				 
		}

		public static PublicReadonlyFieldWithNamesInConstructorNoAttributes CreateInstance()
		{
			return new PublicReadonlyFieldWithNamesInConstructorNoAttributes(Guid.NewGuid(), DateTime.Now.Date.AddSeconds(543).ToLocalTime(), "test", 10, new Uri("http://www.google.com"));
				
		}

		public void AssertEquality(object other)
		{
			Assert.IsNotNull(other);
			Assert.IsInstanceOfType<PublicReadonlyFieldWithNamesInConstructorNoAttributes>(other);

			PublicReadonlyFieldWithNamesInConstructorNoAttributes target = other as PublicReadonlyFieldWithNamesInConstructorNoAttributes;

			Assert.AreEqual(this.Id, target.Id);
			Assert.AreApproximatelyEqual(this.Date.ToUniversalTime(), target.Date.ToUniversalTime(),TimeSpan.FromSeconds(1));
			Assert.AreEqual(this.Text, target.Text);
			Assert.AreEqual(this.Number, target.Number);
			Assert.AreEqual(this.Uri, target.Uri);
		}

	}
}
