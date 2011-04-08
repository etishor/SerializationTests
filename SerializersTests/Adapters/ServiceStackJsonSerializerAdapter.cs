using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerializersTests.Adapters
{
    public class ServiceStackJsonSerializerAdapter : ISerializerAdapter
    {
        public void Serialize<T>(System.IO.Stream stream, T instance)
        {
            EventStore.Serialization.ServiceStackJsonSerializer ser = new EventStore.Serialization.ServiceStackJsonSerializer();
            ser.Serialize(new IndisposableStream(stream), instance);
        }

        public T Deserialize<T>(System.IO.Stream stream)
        {
            EventStore.Serialization.ServiceStackJsonSerializer ser = new EventStore.Serialization.ServiceStackJsonSerializer();
            return ser.Deserialize<T>(new IndisposableStream(stream));
        }
    }
}
