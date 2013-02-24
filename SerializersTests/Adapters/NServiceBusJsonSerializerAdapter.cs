using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NServiceBus.MessageInterfaces.MessageMapper.Reflection;
using NServiceBus.Serializers.Json;

namespace SerializersTests.Adapters
{
    public class NServiceBusJsonSerializerAdapter : ISerializerAdapter
    {
		private readonly JsonMessageSerializer serializer = CreateSerializer();

		private static JsonMessageSerializer CreateSerializer()
		{
			var mapper = new MessageMapper();
			var ser = new JsonMessageSerializer(mapper);

            //ser.JsonSerializerSettings.ContractResolver = new DefaultContractResolver
            //{
            //    DefaultMembersSearchFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance
            //};

            //ser.JsonSerializerSettings.MissingMemberHandling = MissingMemberHandling.Error;
            //ser.JsonSerializerSettings.TypeNameHandling = TypeNameHandling.All;

			return ser;
		}

		public void Serialize(System.IO.Stream stream, object instance)
		{
			serializer.Serialize(new object[] { instance }, stream);
		}

		public object Deserialize(System.IO.Stream stream, Type type)
		{
			return serializer.Deserialize(stream).Single();
		}
	}
}
