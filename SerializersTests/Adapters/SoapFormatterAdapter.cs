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

        public void Serialize<T>(System.IO.Stream stream, T instance)
        {
            serializer.Serialize(stream, instance);
        }

        public T Deserialize<T>(System.IO.Stream stream)
        {
            return (T)serializer.Deserialize(stream);
        }
    }
}
