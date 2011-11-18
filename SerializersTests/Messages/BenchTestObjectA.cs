using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using MbUnit.Framework;
using ProtoBuf;

namespace SerializersTests.Messages
{
    [Serializable]
    [DataContract]
    [ProtoContract]
    public class BenchTestObjectA : IAssertEquality
    {
        public static BenchTestObjectA CreateInstance()
        {
            return CreateChildInstance(0);
        }
        
        public static BenchTestObjectA CreateChildInstance(int level)
        {
            BenchTestObjectA instance = new BenchTestObjectA();

            instance.StringData = Helper.CreateRandomString(128);
			instance.Integer = 100;
            List<string> data = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                data.Add(Helper.CreateRandomString(128));
            }
            instance.Data = data.ToArray();
            
            if (level < 3)
            {
                List<BenchTestObjectA> children = new List<BenchTestObjectA>();
                for (int i = 0; i < 9; i++)
                {
                    children.Add(BenchTestObjectA.CreateChildInstance(level + 1));
                }
                instance.Children = children.ToArray();

            }
            return instance;
        }

        [DataMember]
        [ProtoMember(1)]
        public string StringData { get; set; }

        [DataMember]
        [ProtoMember(4)]
        public string[] Data { get; set; }

        [DataMember]
        [ProtoMember(5)]
        public BenchTestObjectA[] Children { get; set; }

		[DataMember]
		[ProtoMember(6)]
		public int Integer { get; set; }

        public void AssertEquality(object other)
        {
            Assert.IsNotNull(other);
            Assert.IsInstanceOfType<BenchTestObjectA>(other);
            BenchTestObjectA target = other as BenchTestObjectA;

            Assert.AreEqual(this.StringData, target.StringData);
            Assert.AreEqual(this.Data, target.Data);

            if (this.Children != null && target.Children != null)
            {
                Assert.AreEqual(this.Children.Count(), target.Children.Count());
                for (int i = 0; i < this.Children.Count(); i++)
                {
                    this.Children[i].AssertEquality(target.Children[i]);
                }
            }
        }
    }
}
