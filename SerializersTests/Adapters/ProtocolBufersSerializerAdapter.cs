using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerializersTests.Adapters
{
    public class ProtocolBufersSerializerAdapter : ISerializerAdapter
    {
        public void Serialize<T>(System.IO.Stream stream, T instance)
        {
            ProtoBuf.Serializer.Serialize(stream, instance);
        }

        public T Deserialize<T>(System.IO.Stream stream)
        {
            return ProtoBuf.Serializer.Deserialize<T>(stream);
        }
    }

}
