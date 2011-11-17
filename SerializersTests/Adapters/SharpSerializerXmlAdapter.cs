
namespace SerializersTests.Adapters
{
    using Polenter.Serialization;

    /// <summary>
    /// Adapter based on binary serialization with http://www.sharpserializer.com
    /// </summary>
    public class SharpSerializerXmlAdapter : ISerializerAdapter
    {
        private readonly SharpSerializer serializer = new SharpSerializer();

        public void Serialize<T>(System.IO.Stream stream, T instance)
        {
            serializer.Serialize(instance, stream);
        }

        public T Deserialize<T>(System.IO.Stream stream)
        {
            return (T)serializer.Deserialize(stream);
        }
    }
}
