using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SerializersTests.Adapters
{
    public class NetDataContractSerializerAdapter : ISerializerAdapter
    {
		public void Serialize(System.IO.Stream stream, object instance)
		{
			NetDataContractSerializer serializer = new NetDataContractSerializer();
			serializer.WriteObject(stream, instance);
		}

		public object Deserialize(System.IO.Stream stream, Type type)
		{
			NetDataContractSerializer serializer = new NetDataContractSerializer();
			return serializer.ReadObject(stream);
		}
	}
}
