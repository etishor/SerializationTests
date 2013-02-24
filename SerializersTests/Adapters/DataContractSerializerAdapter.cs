using System;
using System.Runtime.Serialization;

namespace SerializersTests.Adapters
{

    public class DataContractSerializerAdapter : ISerializerAdapter
    {
		public void Serialize(System.IO.Stream stream, object instance)
		{
			DataContractSerializer serializer = new DataContractSerializer(instance.GetType());
			serializer.WriteObject(stream, instance);
		}

		public object Deserialize(System.IO.Stream stream, Type type)
		{
			DataContractSerializer serializer = new DataContractSerializer(type);
			return serializer.ReadObject(stream);
		}
	}

}
