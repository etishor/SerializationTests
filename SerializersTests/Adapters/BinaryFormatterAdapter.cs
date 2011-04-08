using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializersTests.Adapters
{
    public class BinaryFormatterAdapter : ISerializerAdapter
    {
        private readonly BinaryFormatter serializer = new BinaryFormatter();

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
