namespace SerializersTests
{
	using System;
	using System.Collections.Generic;
	using System.Reflection;
	using MbUnit.Framework;
	using Raven.Tests;
	
	public class RavenDbTests : LocalClientTest
	{
		[StaticTestFactory]
		public static IEnumerable<Test> CreateTests()
		{
			TestSuite test = new TestSuite(@"Raven Tests");

			foreach (Type message in SerializationTests.GetMessages())
			{
				test.Children.Add(BuildTestCase(message));
			}

			yield return test;
		}

		private static Test BuildTestCase(Type message)
		{
			string name = string.Format("RavenDb_{0}", message.Name);
			TestCase test = new TestCase(name, () => new RavenDbTests().RunTest(message));
			return test;
		}

		private void RunTest(Type messageType)
		{
			IAssertEquality message = (IAssertEquality)messageType.GetMethod("CreateInstance",
				BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy).Invoke(null, null);


			using (var store = NewDocumentStore())
			{
				using (var session = store.OpenSession())
				{
					session.Store(message, "test");
					session.SaveChanges();
				}

				using (var session = store.OpenSession())
				{

					var result = session.Load<IAssertEquality>("test");
					message.AssertEquality(result);
				}
			}

		}

	}
}
