using System;
using System.IO;
using System.Reflection;
using System.Text;
using Raven.Imports.Newtonsoft.Json;
using Raven.Imports.Newtonsoft.Json.Serialization;
using Raven.Json.Linq;

namespace SerializersTests.Adapters
{
	public class RavenJsonAdapter : ISerializerAdapter
    {
		private readonly JsonSerializer serializer = new JsonSerializer()
		{
			MissingMemberHandling = MissingMemberHandling.Error,
			TypeNameHandling = TypeNameHandling.All,
			ContractResolver = new DefaultContractResolver
			{
				DefaultMembersSearchFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance
			}
		};

		protected object Deserialize(JsonReader reader, Type type)
		{
			using (RavenJTokenReader tokenReader = new RavenJTokenReader(RavenJToken.ReadFrom(reader)))
			{
				return serializer.Deserialize(tokenReader, type);
			}
		}

		public virtual void Serialize(Stream stream, object instance)
		{
			using (var streamWriter = new StreamWriter(stream, Encoding.UTF8))
			using (var jsonWriter = new JsonTextWriter(streamWriter))
			{
				RavenJToken.FromObject(instance, this.serializer).WriteTo(jsonWriter);
			}
		}

		public virtual object Deserialize(Stream stream, System.Type type)
		{
			using (StreamReader r = new StreamReader(stream))
			using (var jsonReader = new JsonTextReader(r))
			using (RavenJTokenReader tokenReader = new RavenJTokenReader(RavenJToken.ReadFrom(jsonReader)))
			{
				return serializer.Deserialize(tokenReader, type);
			}
		}

    }
}
