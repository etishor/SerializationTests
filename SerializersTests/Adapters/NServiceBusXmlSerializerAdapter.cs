using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;

namespace SerializersTests.Adapters
{
    public class NServiceBusXmlSerializerAdapter : ISerializerAdapter
    {
        NServiceBus.Serializers.XML.MessageSerializer serializer = new NServiceBus.Serializers.XML.MessageSerializer()
        {
            MessageMapper = new NServiceBus.MessageInterfaces.MessageMapper.Reflection.MessageMapper(),
            MessageTypes = SerializationTests.GetMessages().ToList()
        };

        public void Serialize<T>(System.IO.Stream stream, T instance)
        {
            serializer.Serialize(new NServiceBus.IMessage[] { (IMessage)instance }, stream);
        }

        public T Deserialize<T>(System.IO.Stream stream)
        {
            return (T)serializer.Deserialize(stream).Single();
        }
    }
}
