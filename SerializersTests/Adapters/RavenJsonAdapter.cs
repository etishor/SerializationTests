using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Raven.Json.Linq;
using Newtonsoft.Json;
using System.IO;

namespace SerializersTests.Adapters
{
    public class RavenJsonAdapter : NewtonsoftJsonNetAdapter
    {
        protected override void Serialize(JsonWriter writer, object graph)
        {
            RavenJToken.FromObject(graph, base.serializer).WriteTo(writer);
        }

        protected override T Deserialize<T>(JsonReader reader)
        {
            using (RavenJTokenReader tokenReader = new RavenJTokenReader(RavenJToken.ReadFrom(reader)))
            {
                return base.Deserialize<T>(tokenReader);
            }
        }
    }
}
