using ServiceStack.Text;

namespace SerializersTests.Adapters
{
    public class ServiceStackJsonSerializerAdapter : ISerializerAdapter
    {
        public void Serialize<T>(System.IO.Stream stream, T instance)
        {
            JsonSerializer.SerializeToStream(instance, new IndisposableStream(stream));
        }

        public T Deserialize<T>(System.IO.Stream stream)
        {
            return JsonSerializer.DeserializeFromStream<T>(stream);
        }
    }
}
