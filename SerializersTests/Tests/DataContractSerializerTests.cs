using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using System.Runtime.Serialization;
using SerializersTests.Messages;

namespace SerializersTests.Tests
{
    [TestFixture]
    public class DataContractSerializerTests
    {
        public class DataContractAdapter<T> : ISerializerAdapter<T>
            where T : IAssertEquality
        {
            private readonly DataContractSerializer serializer = new DataContractSerializer(typeof(T));

            public void Serialize(System.IO.Stream stream, T instance)
            {
                serializer.WriteObject(stream, instance);
            }

            public T Deserialize(System.IO.Stream stream)
            {
                return (T)serializer.ReadObject(stream);
            }
        }

        [Test]
        public void DataContractSerializer_PublicSetter()
        {
            SerializationHelper.Test<PublicSetter, DataContractAdapter<PublicSetter>>();
        }

        [Test]
        public void DataContractSerializer_PublicReadOnlyNamesInConstructor()
        {
            SerializationHelper.Test<PublicReadOnlyNamesInConstructor, DataContractAdapter<PublicReadOnlyNamesInConstructor>>();
        }

        [Test]
        public void DataContractSerializer_PublicReadOnlyNamesNotInConstructor()
        {
            SerializationHelper.Test<PublicReadOnlyNamesNotInConstructor, DataContractAdapter<PublicReadOnlyNamesNotInConstructor>>();
        }

        [Test]
        public void DataContractSerializer_PrivateSetterNamesInConstructor()
        {
            SerializationHelper.Test<PrivateSetterNamesInConstructor, DataContractAdapter<PrivateSetterNamesInConstructor>>();
        }

        [Test]
        public void DataContractSerializer_PrivateSetterNamesNotInConstructor()
        {
            SerializationHelper.Test<PrivateSetterNamesNotInConstructor, DataContractAdapter<PrivateSetterNamesNotInConstructor>>();
        }
        
        
    }
}
