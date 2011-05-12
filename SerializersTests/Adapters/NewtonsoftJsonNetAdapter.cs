﻿using System;
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

        public virtual void Serialize<T>(Stream stream, T instance)
        {
            using (var streamWriter = new StreamWriter(stream, Encoding.UTF8))
            using(var jsonWriter = new JsonTextWriter(streamWriter))
            {
                this.Serialize(jsonWriter, instance);
            }
        }

        protected virtual void Serialize(JsonWriter writer, object graph)
        {
            this.serializer.Serialize(writer, graph);
        }

        public virtual T Deserialize<T>(System.IO.Stream stream)
        {
            using (StreamReader r = new StreamReader(stream))
            using(var jsonReader = new JsonTextReader(r))
            {
                return this.Deserialize<T>(jsonReader);
            }
        }

        protected virtual T Deserialize<T>(JsonReader reader)
        {
            return serializer.Deserialize<T>(reader);
        }
    }
}
