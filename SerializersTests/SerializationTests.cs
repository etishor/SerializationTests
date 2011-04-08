using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;
using System.Reflection;
using System.IO;

namespace SerializersTests
{
    /// <summary>
    /// Test generator class.
    /// The CreateTests method scans the assembly for ISerializerAdapter types and IAssertEquality types 
    /// and generates a TestSuite for each Adapter with a TestCase for each Message.
    /// </summary>
    /// <remarks>
    /// To test with new messages just create them implementing IAssertEquality.
    /// To test new serializers jsut create them implementing ISerializerAdapter.
    /// </remarks>
    public class SerializationTests
    {
        [StaticTestFactory]
        public static IEnumerable<Test> CreateTests()
        {
            foreach (Type serializer in GetSerializers())
            {
                string name = serializer.Name.Replace("Adapter`1","");

                TestSuite test = new TestSuite(name);
                foreach(Type message in GetMessages())
                {
                    test.Children.Add(BuildTestCase(serializer, message));
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

        private static void RunTest(Type serializerType, Type messageType)
        {
            ISerializerAdapter serializer = (ISerializerAdapter)Activator.CreateInstance(serializerType);
            IAssertEquality message =(IAssertEquality)messageType.GetMethod("CreateInstance", 
                BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy).Invoke(null, null);

            using (MemoryStream ms = new MemoryStream())
            {
                MethodInfo serializeMethod = serializerType.GetMethod("Serialize");
                MethodInfo genericSerialize = serializeMethod.MakeGenericMethod(messageType);
                genericSerialize.Invoke(serializer, new object[] { ms, message });

                ms.Flush();
                ms.Seek(0, SeekOrigin.Begin);

                MethodInfo deserializeMethod = serializerType.GetMethod("Deserialize");
                MethodInfo genericDeserialize = deserializeMethod.MakeGenericMethod(messageType);
                object output = genericDeserialize.Invoke(serializer, new object[] { ms });

                Assert.IsNotNull(output);
                                
                message.AssertEquality(output);                
            }
        }

        private static IEnumerable<Type> GetSerializers()
        {
            return typeof(ISerializerAdapter).Assembly.GetTypes()
                .Where(t => !t.IsInterface)
                .Where(t => typeof(ISerializerAdapter).IsAssignableFrom(t));
        }

        private static IEnumerable<Type> GetMessages()
        {
            return typeof(IAssertEquality).Assembly.GetTypes()
                .Where(t => !t.IsInterface)
                .Where(t => typeof(IAssertEquality).IsAssignableFrom(t));
        }
    }
}
