using System;
using System.Linq;

namespace SerializersTests.Adapters
{
    public class NServiceBusXmlSerializerAdapter : ISerializerAdapter
    {
		NServiceBus.Serializers.XML.XmlMessageSerializer serializer = new NServiceBus.Serializers.XML.XmlMessageSerializer(
			new NServiceBus.MessageInterfaces.MessageMapper.Reflection.MessageMapper()
			)
        {
        };

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
