﻿
namespace SerializersTests.Adapters
{
    using Polenter.Serialization;

    /// <summary>
    /// Adapter based on binary serialization with http://www.sharpserializer.com
    /// </summary>
    public class SharpSerializerXmlAdapter : ISerializerAdapter
    {
        private readonly SharpSerializer serializer = new SharpSerializer();

		public void Serialize(System.IO.Stream stream, object instance)
		{
			serializer.Serialize(instance, stream);
		}

		public object Deserialize(System.IO.Stream stream, System.Type type)
		{
			return serializer.Deserialize(stream);
		}
	}
}
