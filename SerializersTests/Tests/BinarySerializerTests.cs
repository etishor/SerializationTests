using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using System.Runtime.Serialization.Formatters.Binary;
using SerializersTests.Messages;

namespace SerializersTests.Tests
{
    [TestFixture]
    public class BinarySerializerTests
    {
        public class BinaryAdapter<T> : ISerializerAdapter<T>
            where T : IAssertEquality
        {
            private readonly BinaryFormatter serializer = new BinaryFormatter();

            public void Serialize(System.IO.Stream stream, T instance)
            {                
                serializer.Serialize(stream, instance);
            }

            public T Deserialize(System.IO.Stream stream)
            {
                return (T)serializer.Deserialize(stream);
            }
        }

        [Test]
        public void BinarySerializer_PublicSetter()
        {
            SerializationHelper.Test<PublicSetter, BinaryAdapter<PublicSetter>>();
        }

        [Test]
        public void BinarySerializer_PublicReadOnlyNamesInConstructor()
        {
            SerializationHelper.Test<PublicReadOnlyNamesInConstructor, BinaryAdapter<PublicReadOnlyNamesInConstructor>>();
        }

        [Test]
        public void BinarySerializer_PublicReadOnlyNamesNotInConstructor()
        {
            SerializationHelper.Test<PublicReadOnlyNamesNotInConstructor, BinaryAdapter<PublicReadOnlyNamesNotInConstructor>>();
        }

        [Test]
        public void BinarySerializer_PrivateSetterNamesInConstructor()
        {
            SerializationHelper.Test<PrivateSetterNamesInConstructor, BinaryAdapter<PrivateSetterNamesInConstructor>>();
        }

        [Test]
        public void BinarySerializer_PrivateSetterNamesNotInConstructor()
        {
            SerializationHelper.Test<PrivateSetterNamesNotInConstructor, BinaryAdapter<PrivateSetterNamesNotInConstructor>>();
        }
    }
}
