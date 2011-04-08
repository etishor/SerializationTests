using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;

namespace SerializersTests.Adapters
{
    public class NServiceBusXmlSerializerAdapter : ISerializerAdapter
    {
        public void Serialize<T>(System.IO.Stream stream, T instance)
        {
            NServiceBus.Serializers.XML.MessageSerializer serializer = new NServiceBus.Serializers.XML.MessageSerializer();
            serializer.MessageMapper = new NServiceBus.MessageInterfaces.MessageMapper.Reflection.MessageMapper();
            serializer.MessageMapper.Initialize(new Type[] { typeof(T) });
            serializer.InitType(typeof(T));
            serializer.Serialize(new NServiceBus.IMessage[] { (IMessage)instance }, stream);
        }

        public T Deserialize<T>(System.IO.Stream stream)
        {
            NServiceBus.Serializers.XML.MessageSerializer serializer = new NServiceBus.Serializers.XML.MessageSerializer();
            serializer.MessageMapper = new NServiceBus.MessageInterfaces.MessageMapper.Reflection.MessageMapper();
            serializer.MessageMapper.Initialize(new Type[] { typeof(T) });
            serializer.InitType(typeof(T));
            return (T)serializer.Deserialize(stream).Single();
        }
    }
}
