using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SerializersTests.Adapters
{
    public class XmlSerializerAdapter : ISerializerAdapter
    {
        public void Serialize<T>(System.IO.Stream stream, T instance)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(stream, instance);
        }

        public T Deserialize<T>(System.IO.Stream stream)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(stream);
        }
    }
}
