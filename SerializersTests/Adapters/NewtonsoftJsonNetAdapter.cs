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
        public void Serialize<T>(System.IO.Stream stream, T instance)
        {
            string json = JsonConvert.SerializeObject(instance);
            byte[] data = Encoding.UTF8.GetBytes(json);
            stream.Write(data, 0, data.Length);
        }

        public T Deserialize<T>(System.IO.Stream stream)
        {
            using (StreamReader r = new StreamReader(stream))
            {
                return JsonConvert.DeserializeObject<T>(r.ReadToEnd());
            }
        }       
    }
}
