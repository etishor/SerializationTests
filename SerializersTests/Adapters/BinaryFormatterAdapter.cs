using System;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializersTests.Adapters
{
    public class BinaryFormatterAdapter : ISerializerAdapter
    {
        private readonly BinaryFormatter serializer = new BinaryFormatter();

		public void Serialize(System.IO.Stream stream, object instance)
		{
			serializer.Serialize(stream, instance);
		}

		public object Deserialize(System.IO.Stream stream, Type type)
		{
			return serializer.Deserialize(stream);
		}
	}    
}
