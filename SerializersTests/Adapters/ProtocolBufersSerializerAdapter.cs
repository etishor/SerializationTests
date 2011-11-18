using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerializersTests.Adapters
{
    public class ProtocolBufersSerializerAdapter : ISerializerAdapter
    {
		public void Serialize(System.IO.Stream stream, object instance)
		{
			ProtoBuf.Serializer.NonGeneric.Serialize(stream, instance);
		}

		public object Deserialize(System.IO.Stream stream, Type type)
		{
			return ProtoBuf.Serializer.NonGeneric.Deserialize(type, stream);
		}
	}

}
