using System;
using System.Linq;

namespace SerializersTests.Adapters
{
    public class NServiceBusBinarySerializerAdapter  : ISerializerAdapter
    {
		private readonly NServiceBus.Serializers.Binary.MessageSerializer serializer =
            new NServiceBus.Serializers.Binary.MessageSerializer();

		public void Serialize(System.IO.Stream stream, object instance)
		{
			serializer.Serialize(new object[] { instance }, stream);
		}

		public object Deserialize(System.IO.Stream stream, Type type)
		{
			return serializer.Deserialize(stream).Single();
		}
	}

}
