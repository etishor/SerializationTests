using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Json.Linq;
using Newtonsoft.Json;
using System.IO;

namespace SerializersTests.Adapters
{
    public class RavenJsonAdapter : ISerializerAdapter
    {
        private readonly JsonSerializer serializer = new JsonSerializer();

        public void Serialize<T>(System.IO.Stream stream, T instance)
        {
            var o = RavenJObject.FromObject(instance);
            
            using(var text = new StreamWriter(new IndisposableStream(stream)))
            {
                using(var jsonWriter = new JsonTextWriter(text))
                {
                    o.WriteTo(jsonWriter);
                }
            }
        }

        public T Deserialize<T>(System.IO.Stream stream)
        {
            using (var text = new StreamReader(new IndisposableStream(stream)))
            {
                using(var jsonReader = new JsonTextReader(text))
                {
                    var jobject = RavenJObject.ReadFrom(jsonReader);

                    return serializer.Deserialize<T>(new RavenJTokenReader(jobject));
                }
            }
        }
    }
}
