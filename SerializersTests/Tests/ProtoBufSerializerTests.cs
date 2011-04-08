using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using ProtoBuf;

namespace SerializersTests.Tests
{

    [TestFixture]
    public class ProtoBufSerializerTests
    {
        public class ProtoBufAdapter<T> : ISerializerAdapter<T>
            where T : IAssertEquality
        {
            public void Serialize(System.IO.Stream stream, T instance)
            {
                Serializer.Serialize(stream, instance);
            }

            public T Deserialize(System.IO.Stream stream)
            {
                return Serializer.Deserialize<T>(stream);
            }
        }

        

            [Test]
        public void ProtoBuf_PublicSetter()
        {
            SerializationHelper.Test<PublicSetter, ProtoBufAdapter<PublicSetter>>();
        }

        [Test]
        public void ProtoBuf_PublicReadOnlyNamesInConstructor()
        {
            SerializationHelper.Test<PublicReadOnlyNamesInConstructor, ProtoBufAdapter<PublicReadOnlyNamesInConstructor>>();
        }

        [Test]
        public void ProtoBuf_PublicReadOnlyNamesNotInConstructor()
        {
            SerializationHelper.Test<PublicReadOnlyNamesNotInConstructor, ProtoBufAdapter<PublicReadOnlyNamesNotInConstructor>>();
        }

        [Test]
        public void ProtoBuf_PrivateSetterNamesInConstructor()
        {
            SerializationHelper.Test<PrivateSetterNamesInConstructor, ProtoBufAdapter<PrivateSetterNamesInConstructor>>();
        }

         [Test]
        public void ProtoBuf_PrivateSetterNamesNotInConstructor()
        {
            SerializationHelper.Test<PrivateSetterNamesNotInConstructor, ProtoBufAdapter<PrivateSetterNamesNotInConstructor>>();
        }


        
    }
}
