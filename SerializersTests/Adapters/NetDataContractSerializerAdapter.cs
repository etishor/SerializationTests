using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace SerializersTests.Adapters
{
    public class NetDataContractSerializerAdapter : ISerializerAdapter
    {
        public void Serialize<T>(System.IO.Stream stream, T instance)
        {
            NetDataContractSerializer serializer = new NetDataContractSerializer();
            serializer.WriteObject(stream, instance);
        }

        public T Deserialize<T>(System.IO.Stream stream)
        {
            NetDataContractSerializer serializer = new NetDataContractSerializer();
            return (T)serializer.ReadObject(stream);
        }       
    }
}
