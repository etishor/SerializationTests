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
    public class NServiceBusBinarySerializerTests
    {
        public class NServiceBusBinarySerializerAdapter<T> : ISerializerAdapter<T>
            where T : IAssertEquality
        {
            private readonly NServiceBus.Serializers.Binary.MessageSerializer serializer = new NServiceBus.Serializers.Binary.MessageSerializer();
            public NServiceBusBinarySerializerAdapter()
            {
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
        public void NServiceBusBinarySerializer_PublicSetter()
        {
            SerializationHelper.Test<PublicSetter, NServiceBusBinarySerializerAdapter<PublicSetter>>();
        }

        [Test]
        public void NServiceBusBinarySerializer_PublicReadOnlyNamesInConstructor()
        {
            SerializationHelper.Test<PublicReadOnlyNamesInConstructor, NServiceBusBinarySerializerAdapter<PublicReadOnlyNamesInConstructor>>();
        }

        [Test]
        public void NServiceBusBinarySerializer_PublicReadOnlyNamesNotInConstructor()
        {
            SerializationHelper.Test<PublicReadOnlyNamesNotInConstructor, NServiceBusBinarySerializerAdapter<PublicReadOnlyNamesNotInConstructor>>();
        }

        [Test]
        public void NServiceBusBinarySerializer_PrivateSetterNamesInConstructor()
        {
            SerializationHelper.Test<PrivateSetterNamesInConstructor, NServiceBusBinarySerializerAdapter<PrivateSetterNamesInConstructor>>();
        }

        [Test]
        public void NServiceBusBinarySerializer_PrivateSetterNamesNotInConstructor()
        {
            SerializationHelper.Test<PrivateSetterNamesNotInConstructor, NServiceBusBinarySerializerAdapter<PrivateSetterNamesNotInConstructor>>();
        }


    }
}
