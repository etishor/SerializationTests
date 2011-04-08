using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using System.Xml.Serialization;

namespace SerializersTests.Tests
{
    [TestFixture]
    public class XmlSerializerTests
    {
        public class XmlSerializerAdapter<T> : ISerializerAdapter<T>
            where T : IAssertEquality
        {
            private readonly XmlSerializer serializer = new XmlSerializer(typeof(T));

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
        public void XmlSerializer_PublicSetter()
        {
            SerializationHelper.Test<PublicSetter, XmlSerializerAdapter<PublicSetter>>();
        }

        [Test]
        public void XmlSerializer_PublicReadOnlyNamesInConstructor()
        {
            SerializationHelper.Test<PublicReadOnlyNamesInConstructor, XmlSerializerAdapter<PublicReadOnlyNamesInConstructor>>();
        }

        [Test]
        public void XmlSerializer_PublicReadOnlyNamesNotInConstructor()
        {
            SerializationHelper.Test<PublicReadOnlyNamesNotInConstructor, XmlSerializerAdapter<PublicReadOnlyNamesNotInConstructor>>();
        }

        [Test]
        public void XmlSerializer_PrivateSetterNamesInConstructor()
        {
            SerializationHelper.Test<PrivateSetterNamesInConstructor, XmlSerializerAdapter<PrivateSetterNamesInConstructor>>();
        }

        [Test]
        public void XmlSerializer_PrivateSetterNamesNotInConstructor()
        {
            SerializationHelper.Test<PrivateSetterNamesNotInConstructor, XmlSerializerAdapter<PrivateSetterNamesNotInConstructor>>();
        }
        
        
    }
}
