using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;

namespace SerializersTests.Tests
{
    [TestFixture]
    public class ServiceStackJsonSerializationTests
    {
        public class ServiceStackJsonAdapter<T> : ISerializerAdapter<T>
            where T : IAssertEquality
        {
            private readonly EventStore.Serialization.ServiceStackJsonSerializer ser = new EventStore.Serialization.ServiceStackJsonSerializer();
            public void Serialize(System.IO.Stream stream, T instance)
            {

                ser.Serialize( new IndisposableStream(stream), instance);
            }

            public T Deserialize(System.IO.Stream stream)
            {
                return ser.Deserialize<T>(new IndisposableStream(stream));
            }
        }


        [Test]
        public void ServiceStackJson_PublicSetter()
        {
            SerializationHelper.Test<PublicSetter, ServiceStackJsonAdapter<PublicSetter>>();
        }

        [Test]
        public void ServiceStackJson_PublicReadOnlyNamesInConstructor()
        {
            SerializationHelper.Test<PublicReadOnlyNamesInConstructor, ServiceStackJsonAdapter<PublicReadOnlyNamesInConstructor>>();
        }

        [Test]
        public void ServiceStackJson_PublicReadOnlyNamesNotInConstructor()
        {
            SerializationHelper.Test<PublicReadOnlyNamesNotInConstructor, ServiceStackJsonAdapter<PublicReadOnlyNamesNotInConstructor>>();
        }

        [Test]
        public void ServiceStackJson_PrivateSetterNamesInConstructor()
        {
            SerializationHelper.Test<PrivateSetterNamesInConstructor, ServiceStackJsonAdapter<PrivateSetterNamesInConstructor>>();
        }

        [Test]
        public void ServiceStackJson_PrivateSetterNamesNotInConstructor()
        {
            SerializationHelper.Test<PrivateSetterNamesNotInConstructor, ServiceStackJsonAdapter<PrivateSetterNamesNotInConstructor>>();
        }
    }      
}
