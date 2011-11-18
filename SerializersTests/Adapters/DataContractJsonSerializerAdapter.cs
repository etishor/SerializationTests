using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;

namespace SerializersTests.Adapters
{
    public class DataContractJsonSerializerAdapter : ISerializerAdapter
    {
		public void Serialize(System.IO.Stream stream, object instance)
		{
			DataContractJsonSerializer serializer = new DataContractJsonSerializer(instance.GetType());
			serializer.WriteObject(stream, instance);
		}

		public object Deserialize(System.IO.Stream stream, Type type)
		{
			DataContractJsonSerializer serializer = new DataContractJsonSerializer(type);
			return serializer.ReadObject(stream);
		}
	}
}
