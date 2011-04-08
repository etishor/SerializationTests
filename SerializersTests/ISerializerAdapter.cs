using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SerializersTests
{
    /// <summary>
    /// Common, generic interface for message serializers.
    /// </summary>
    public interface ISerializerAdapter
    {
        void Serialize<T>(Stream stream, T instance);
        T Deserialize<T>(Stream stream);
    }
}
