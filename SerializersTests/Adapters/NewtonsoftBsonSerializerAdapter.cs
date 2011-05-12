using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json.Bson;

namespace SerializersTests.Adapters
{
    public class NewtonsoftBsonSerializerAdapter : NewtonsoftJsonNetAdapter
    {
        public override void Serialize<T>(System.IO.Stream stream, T instance)
        {
            using (var writer = new BsonWriter(stream))
            {
                base.Serialize(writer, instance);
            }
        }

        public override T Deserialize<T>(Stream stream)
        {
            using (var reader = new BsonReader(stream))
            {
                return this.Deserialize<T>(reader);
            }
        }
    }
}
