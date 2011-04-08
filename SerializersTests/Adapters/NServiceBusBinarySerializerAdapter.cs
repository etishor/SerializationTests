using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;

namespace SerializersTests.Adapters
{
    public class NServiceBusBinarySerializerAdapter : ISerializerAdapter
    {
        private readonly NServiceBus.Serializers.Binary.MessageSerializer serializer = new NServiceBus.Serializers.Binary.MessageSerializer();

        public void Serialize<T>(System.IO.Stream stream, T instance)
        {
            serializer.Serialize(new IMessage[] { (IMessage)instance }, stream);
        }

        public T Deserialize<T>(System.IO.Stream stream)
        {
            return (T)serializer.Deserialize(stream).Single();
        }
    }

}
