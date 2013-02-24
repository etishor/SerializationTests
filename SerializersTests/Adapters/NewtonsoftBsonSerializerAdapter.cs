using System.IO;
using Newtonsoft.Json.Bson;

namespace SerializersTests.Adapters
{
    public class NewtonsoftBsonSerializerAdapter : NewtonsoftJsonNetAdapter
    {
		public override void Serialize(Stream stream, object instance)
		{
			using (var writer = new BsonWriter(stream))
			{
				base.Serialize(writer, instance);
			}
		}

		public override object Deserialize(Stream stream, System.Type type)
		{
			using (var reader = new BsonReader(stream))
			{
				return this.Deserialize(reader, type);
			}
		}
    }
}
