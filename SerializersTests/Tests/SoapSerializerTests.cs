using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;

namespace SerializersTests.Tests
{
    [TestFixture]
    public class SoapSerializerTests
    {
        public class SoapAdapter<T> : ISerializerAdapter<T>
            where T : IAssertEquality
        {
            private readonly SoapFormatter serializer = new SoapFormatter();

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
        public void SoapSerializer_PublicSetter()
        {
            SerializationHelper.Test<PublicSetter, SoapAdapter<PublicSetter>>();
        }

        [Test]
        public void SoapSerializer_PublicReadOnlyNamesInConstructor()
        {
            SerializationHelper.Test<PublicReadOnlyNamesInConstructor, SoapAdapter<PublicReadOnlyNamesInConstructor>>();
        }

        [Test]
        public void SoapSerializer_PublicReadOnlyNamesNotInConstructor()
        {
            SerializationHelper.Test<PublicReadOnlyNamesNotInConstructor, SoapAdapter<PublicReadOnlyNamesNotInConstructor>>();
        }

        [Test]
        public void SoapSerializer_PrivateSetterNamesInConstructor()
        {
            SerializationHelper.Test<PrivateSetterNamesInConstructor, SoapAdapter<PrivateSetterNamesInConstructor>>();
        }

        [Test]
        public void SoapSerializer_PrivateSetterNamesNotInConstructor()
        {
            SerializationHelper.Test<PrivateSetterNamesNotInConstructor, SoapAdapter<PrivateSetterNamesNotInConstructor>>();
        }
    }
}
