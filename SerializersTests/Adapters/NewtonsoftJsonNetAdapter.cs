using System;
using System.IO;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SerializersTests.Adapters
{
    public class NewtonsoftJsonNetAdapter : ISerializerAdapter
    {
        protected readonly JsonSerializer serializer = new JsonSerializer()
        {
            MissingMemberHandling = MissingMemberHandling.Error,
            TypeNameHandling = TypeNameHandling.All,
            ContractResolver = new DefaultContractResolver
            {
                DefaultMembersSearchFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance
            }
        };

        protected virtual void Serialize(JsonWriter writer, object graph)
        {
            this.serializer.Serialize(writer, graph);
        }

        protected virtual object Deserialize(JsonReader reader, Type type)
        {
            return serializer.Deserialize(reader, type);
        }

        public virtual void Serialize(Stream stream, object instance)
        {
            using (var streamWriter = new StreamWriter(stream, Encoding.UTF8))
            using (var jsonWriter = new JsonTextWriter(streamWriter))
            {
                this.Serialize(jsonWriter, instance);
            }
        }

        public virtual object Deserialize(Stream stream, System.Type type)
        {
            using (StreamReader r = new StreamReader(stream))
            using (var jsonReader = new JsonTextReader(r))
            {
                return this.Deserialize(jsonReader, type);
            }
        }
    }
}
