using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using MbUnit.Framework;
using ProtoBuf;
using TestDataGenerator;

namespace SerializersTests
{
    /// <summary>
    /// Test generator class.
    /// The CreateTests method scans the assembly for ISerializerAdapter types and IAssertEquality types 
    /// and generates a TestSuite for each Adapter with a TestCase for each Message.
    /// </summary>
    /// <remarks>
    /// To test with new messages just create them implementing IAssertEquality.
    /// To test new serializes just create them implementing ISerializerAdapter.
    /// </remarks>
    public class SerializationTests
    {
		private static Catalog catalog = new Catalog();

        [StaticTestFactory]
        public static IEnumerable<Test> CreateTests()
        {
			catalog.RegisterBuilder<Messages.UriWithQuotesAndSlashes>().WithPostConstruction(m =>
			{
				var tm = m as Messages.UriWithQuotesAndSlashes;
				tm.ValueWithQuotes = new Uri(Messages.UriWithQuotesAndSlashes.UriQuotes);
				tm.ValueWithSlashes = new Uri(Messages.UriWithQuotesAndSlashes.UriSlash);
			});

            foreach (Type serializer in GetSerializers())
            {
                string name = serializer.Name.Replace("Adapter`1","");

                TestSuite test = new TestSuite(name);
                foreach(Type message in GetMessages())
                {
                    test.Children.Add(BuildTestCase(serializer, message));
					test.Children.Add(BuildObjectTreeTestCase(serializer, message));
				}
				foreach (TestCase testCase in BuildEnumerableTests(serializer))
				{
					test.Children.Add(testCase);
				}
				yield return test;
            }
        }

        private static TestCase BuildTestCase(Type serializer, Type message)
        {
            string name = string.Format("{0}_{1}",serializer.Name.Replace("Adapter`1",""),message.Name);
            TestCase test = new TestCase(name, () => RunTest(serializer,message) );            
            return test;
        }

		private static TestCase BuildObjectTreeTestCase(Type serializer, Type message)
		{
			string name = string.Format("{0}_{1}_RndData", serializer.Name.Replace("Adapter`1", ""), message.Name);
			TestCase test = new TestCase(name, () => RunObjectTreeTest(serializer, message));

			return test;
		}

        private static IEnumerable<TestCase> BuildEnumerableTests(Type serializerType)
        {
            string arrayName = string.Format("{0}_ArrayOfCustomObjects", serializerType.Name.Replace("Adapter`1", ""));
            yield return new TestCase(arrayName, () => RunArrayTest(serializerType));

            string listName = string.Format("{0}_ListOfCustomObjects", serializerType.Name.Replace("Adapter`1", ""));
            yield return new TestCase(listName, () => RunListTest(serializerType));
        }
        
        [Serializable]
        [DataContract]
        [ProtoContract]
        private class TestCustomObject
        {
            [DataMember]
            [ProtoMember(1)]
            public object Value { get; set; }
        }


        private static void RunArrayTest(Type serializerType)
        {
            ISerializerAdapter serializer = (ISerializerAdapter)Activator.CreateInstance(serializerType);
            TestCustomObject[] messages = new TestCustomObject[] { new TestCustomObject { Value = 10 } };
            Type messagesType = typeof(TestCustomObject[]);

            using (MemoryStream ms = new MemoryStream())
            {
                object output = null;
                bool ex = false;
                try
                {
					serializer.Serialize(new IndisposableStream(ms), messages);

                    ms.Flush();
                    ms.Seek(0, SeekOrigin.Begin);

					output = serializer.Deserialize(new IndisposableStream(ms), messagesType);
                }
                catch (Exception x)
                {
                    Assert.Inconclusive("The the serializer has at least thrown an exception instead of unexpected results {0}", x);
                    ex = true;
                }
                if (!ex)
                {
                    Assert.IsInstanceOfType(messagesType, output);
                    TestCustomObject[] deserialized = output as TestCustomObject[];
                    Assert.AreEqual(messages.Single().Value.ToString(), deserialized.Single().Value.ToString());
                }
            }
        }

        private static void RunListTest(Type serializerType)
        {
            ISerializerAdapter serializer = (ISerializerAdapter)Activator.CreateInstance(serializerType);
            List<TestCustomObject> messages = new List<TestCustomObject> { new TestCustomObject { Value = 10 } };
            Type messagesType = typeof(List<TestCustomObject>);

            using (MemoryStream ms = new MemoryStream())
            {
                object output = null;
                bool ex = false;
                try
                {
					serializer.Serialize(new IndisposableStream(ms), messages);

                    ms.Flush();
                    ms.Seek(0, SeekOrigin.Begin);

					output = serializer.Deserialize(new IndisposableStream(ms), messagesType);
                }
                catch (Exception x)
                {
                    Assert.Inconclusive("The the serializer has at least thrown an exception instead of unexpected results {0}", x);
                    ex = true;
                }
                if (!ex)
                {
                    Assert.IsInstanceOfType(messagesType, output);
                    List<TestCustomObject> deserialized = output as List<TestCustomObject>;
                    Assert.AreEqual(messages.Single().Value.ToString(), deserialized.Single().Value.ToString());
                }
            }
        }
  
		private static void RunObjectTreeTest(Type serializerType, Type messageType)
		{
			ISerializerAdapter serializer = (ISerializerAdapter)Activator.CreateInstance(serializerType);
			
			object message = catalog.CreateInstance(messageType);

			using (MemoryStream ms = new MemoryStream())
			{
				object output = null;
				bool ex = false;
				try
				{
					serializer.Serialize(new IndisposableStream(ms), message);

					ms.Flush();
					ms.Seek(0, SeekOrigin.Begin);

					output = serializer.Deserialize(new IndisposableStream(ms), messageType);
					
				}
				catch (Exception x)
				{
					Assert.Inconclusive("The the serializer has at least thrown an exception instead of unexpected results {0}", x);
					ex = true;
				}
				if (!ex)
				{
					ObjectDataTree messageData = new ObjectDataTree(message);
					ObjectDataTree outputData = new ObjectDataTree(output);

					Assert.AreEqual(messageData.StringValue(), outputData.StringValue());
					(message as IAssertEquality).AssertEquality(output);
				}
			}			
		}

        private static void RunTest(Type serializerType, Type messageType)
        {
            ISerializerAdapter serializer = (ISerializerAdapter)Activator.CreateInstance(serializerType);
            IAssertEquality message = (IAssertEquality)messageType.GetMethod("CreateInstance",
                BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy).Invoke(null, null);

            using (MemoryStream ms = new MemoryStream())
            {
                object output = null;
                bool ex = false;
                try
                {
					serializer.Serialize(new IndisposableStream(ms), message);
                    ms.Flush();
                    ms.Seek(0, SeekOrigin.Begin);
					output = serializer.Deserialize(new IndisposableStream(ms), messageType);
                }
                catch (Exception x)
                {
                    Assert.Inconclusive("The the serializer has at least thrown an exception instead of unexpected results {0}", x);
                    ex = true;
                }
                if (!ex)
                {
                    message.AssertEquality(output);
                }
            }
        }

        public static IEnumerable<Type> GetSerializers()
        {
            return typeof(ISerializerAdapter).Assembly.GetTypes()
                .Where(t => !t.IsInterface)
                .Where(t => typeof(ISerializerAdapter).IsAssignableFrom(t));
        }

        public static IEnumerable<Type> GetMessages()
        {
            return typeof(IAssertEquality).Assembly.GetTypes()
                .Where(t => !t.IsInterface)
                .Where(t => typeof(IAssertEquality).IsAssignableFrom(t));
        }
    }
}
