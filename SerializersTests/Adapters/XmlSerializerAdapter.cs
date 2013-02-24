using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SerializersTests.Adapters
{
    public class XmlSerializerAdapter : ISerializerAdapter
    {
		public void Serialize(System.IO.Stream stream, object instance)
		{
			XmlSerializer serializer = new XmlSerializer(instance.GetType());
			serializer.Serialize(stream, instance);
		}

		public object Deserialize(System.IO.Stream stream, Type type)
		{
			XmlSerializer serializer = new XmlSerializer(type);
			return serializer.Deserialize(stream);
		}
	}
}
