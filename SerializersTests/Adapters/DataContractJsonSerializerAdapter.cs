using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;

namespace SerializersTests.Adapters
{
    public class DataContractJsonSerializerAdapter : ISerializerAdapter
    {
        public void Serialize<T>(System.IO.Stream stream, T instance)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            serializer.WriteObject(stream, instance);
        }

        public T Deserialize<T>(System.IO.Stream stream)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            return (T)serializer.ReadObject(stream);
        }
    }
}
