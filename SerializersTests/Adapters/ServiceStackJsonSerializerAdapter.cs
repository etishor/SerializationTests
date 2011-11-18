using System.IO;
using ServiceStack.Text;

namespace SerializersTests.Adapters
{
    public class ServiceStackJsonSerializerAdapter : ISerializerAdapter
    {
		public void Serialize(Stream stream, object instance)
		{
			JsonSerializer.SerializeToStream(instance, instance.GetType(), new IndisposableStream(stream));
		}

		public object Deserialize(Stream stream, System.Type type)
		{
			return JsonSerializer.DeserializeFromStream(type,stream);
		}
	}
}
