using System;
using Newtonsoft.Json;
using Raven.Json.Linq;

namespace SerializersTests.Adapters
{
    public class RavenJsonAdapter : NewtonsoftJsonNetAdapter
    {
        protected override void Serialize(JsonWriter writer, object graph)
        {
            RavenJToken.FromObject(graph, base.serializer).WriteTo(writer);
        }

		protected override object Deserialize(JsonReader reader, Type type)
		{
			using (RavenJTokenReader tokenReader = new RavenJTokenReader(RavenJToken.ReadFrom(reader)))
			{
				return base.Deserialize(tokenReader, type);
			}
		}
    }
}
