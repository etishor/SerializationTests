using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using Newtonsoft.Json;
using System.IO;

namespace SerializersTests.Tests
{
    [TestFixture]
    public class JsonNetTests
    {
        public class JsonNetAdapter<T> : ISerializerAdapter<T>
            where T : IAssertEquality
        {
            public void Serialize(System.IO.Stream stream, T instance)
            {
                string json = JsonConvert.SerializeObject(instance);
                byte[] data = Encoding.UTF8.GetBytes(json);
                stream.Write(data, 0, data.Length);
            }

            public T Deserialize(System.IO.Stream stream)
            {
                using(StreamReader r = new StreamReader(stream))
                {
                    return JsonConvert.DeserializeObject<T>(r.ReadToEnd());
                }
            }
        }

        
            [Test]
        public void JsonNet_PublicSetter()
        {
            SerializationHelper.Test<PublicSetter, JsonNetAdapter<PublicSetter>>();
        }

        [Test]
        public void JsonNet_PublicReadOnlyNamesInConstructor()
        {
            SerializationHelper.Test<PublicReadOnlyNamesInConstructor, JsonNetAdapter<PublicReadOnlyNamesInConstructor>>();
        }

        [Test]
        public void JsonNet_PublicReadOnlyNamesNotInConstructor()
        {
            SerializationHelper.Test<PublicReadOnlyNamesNotInConstructor, JsonNetAdapter<PublicReadOnlyNamesNotInConstructor>>();
        }

        [Test]
        public void JsonNet_PrivateSetterNamesInConstructor()
        {
            SerializationHelper.Test<PrivateSetterNamesInConstructor, JsonNetAdapter<PrivateSetterNamesInConstructor>>();
        }

        [Test]
        public void JsonNet_PrivateSetterNamesNotInConstructor()
        {
            SerializationHelper.Test<PrivateSetterNamesNotInConstructor, JsonNetAdapter<PrivateSetterNamesNotInConstructor>>();
        }
        
        
    }
}
