using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using System.IO;
namespace SerializersTests.Adapters
{
    public class JavascriptSerializerAdapter : ISerializerAdapter
    {
        private readonly JavaScriptSerializer serializer = new JavaScriptSerializer() { MaxJsonLength = int.MaxValue, RecursionLimit = int.MaxValue };

		public void Serialize(Stream stream, object instance)
		{
			using (StreamWriter writer = new StreamWriter(stream))
			{
				writer.Write(serializer.Serialize(instance));
			}
		}

		public object Deserialize(Stream stream, Type type)
		{
			using (StreamReader reader = new StreamReader(stream))
			{
				return serializer.Deserialize(reader.ReadToEnd(), type);
			}
		}
	}
}
