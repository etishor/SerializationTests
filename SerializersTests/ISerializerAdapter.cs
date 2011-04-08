using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SerializersTests
{
    public interface ISerializerAdapter
    {
        void Serialize<T>(Stream stream, T instance);
        T Deserialize<T>(Stream stream);
    }
}
