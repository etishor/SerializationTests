using System;
using System.IO;

namespace SerializersTests
{
    /// <summary>
    /// Common, generic interface for message serializes.
    /// </summary>
    public interface ISerializerAdapter
    {
		void Serialize(Stream stream, object instance);
		object Deserialize(Stream stream, Type type);
    }
}
