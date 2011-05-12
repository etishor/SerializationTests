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

        public void Serialize<T>(System.IO.Stream stream, T instance)
        {
            using(StreamWriter writer = new StreamWriter(stream))
            {
                writer.Write(serializer.Serialize(instance));
            }
        }

        public T Deserialize<T>(System.IO.Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                return serializer.Deserialize<T>(reader.ReadToEnd());
            }
        }
    }
}
