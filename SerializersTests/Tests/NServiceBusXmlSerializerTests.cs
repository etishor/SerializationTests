using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using NServiceBus;
using NServiceBus.MessageInterfaces.MessageMapper.Reflection;

namespace SerializersTests.Tests
{
    [TestFixture]
    public class NServiceBusXmlSerializerTests
    {
        public class NServiceBusXmlSerializerAdapter<T> : ISerializerAdapter<T>
            where T : IAssertEquality
        {
            private readonly NServiceBus.Serializers.XML.MessageSerializer serializer = new NServiceBus.Serializers.XML.MessageSerializer();
            public NServiceBusXmlSerializerAdapter()
            {
                serializer.MessageMapper = new MessageMapper();
                serializer.MessageMapper.Initialize(new Type[] { typeof(T) });
                serializer.InitType(typeof(T));
            }

            public void Serialize(System.IO.Stream stream, T instance)
            {
                serializer.Serialize(new IMessage[] { instance }, stream);                
            }

            public T Deserialize(System.IO.Stream stream)
            {
                return (T)serializer.Deserialize(stream).Single();
            }
        }


        [Test]
        public void NServiceBusXmlSerializer_PublicSetter()
        {
            SerializationHelper.Test<PublicSetter, NServiceBusXmlSerializerAdapter<PublicSetter>>();
        }

        [Test]
        public void NServiceBusXmlSerializer_PublicReadOnlyNamesInConstructor()
        {
            SerializationHelper.Test<PublicReadOnlyNamesInConstructor, NServiceBusXmlSerializerAdapter<PublicReadOnlyNamesInConstructor>>();
        }

        [Test]
        public void NServiceBusXmlSerializer_PublicReadOnlyNamesNotInConstructor()
        {
            SerializationHelper.Test<PublicReadOnlyNamesNotInConstructor, NServiceBusXmlSerializerAdapter<PublicReadOnlyNamesNotInConstructor>>();
        }

        [Test]
        public void NServiceBusXmlSerializer_PrivateSetterNamesInConstructor()
        {
            SerializationHelper.Test<PrivateSetterNamesInConstructor, NServiceBusXmlSerializerAdapter<PrivateSetterNamesInConstructor>>();
        }

        [Test]
        public void NServiceBusXmlSerializer_PrivateSetterNamesNotInConstructor()
        {
            SerializationHelper.Test<PrivateSetterNamesNotInConstructor, NServiceBusXmlSerializerAdapter<PrivateSetterNamesNotInConstructor>>();
        }


    }
}
