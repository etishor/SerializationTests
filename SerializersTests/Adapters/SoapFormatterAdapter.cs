using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Soap;

namespace SerializersTests.Adapters
{
    public class SoapFormatterAdapter : ISerializerAdapter
    {
        private readonly SoapFormatter serializer = new SoapFormatter();

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
