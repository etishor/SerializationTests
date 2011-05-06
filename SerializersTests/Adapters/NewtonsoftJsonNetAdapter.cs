using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.IO;

namespace SerializersTests.Adapters
{
    public class NewtonsoftJsonNetAdapter : ISerializerAdapter
    {
        protected readonly JsonSerializer serializer = new JsonSerializer()
        {
            MissingMemberHandling = MissingMemberHandling.Error,
            TypeNameHandling = TypeNameHandling.All
        };

        public void Serialize<T>(Stream stream, T instance)
        {
            using (var streamWriter = new StreamWriter(stream, Encoding.UTF8))
            {
                this.Serialize(new JsonTextWriter(streamWriter), instance);
            }
        }

        protected virtual void Serialize(JsonWriter writer, object graph)
        {
            using (writer)
            {
                this.serializer.Serialize(writer, graph);
            }
        }

        public T Deserialize<T>(System.IO.Stream stream)
        {
            using (StreamReader r = new StreamReader(stream))
            {
                return this.Deserialize<T>(new JsonTextReader(r));
            }
        }

        protected virtual T Deserialize<T>(JsonReader reader)
        {
            using (reader)
            {
                return serializer.Deserialize<T>(reader);
            }
        }
    }
}
