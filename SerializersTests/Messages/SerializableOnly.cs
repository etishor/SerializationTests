using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;

namespace SerializersTests.Messages
{
    [Serializable]
    public class SerializableOnly : IAssertEquality
    {
        public int ValueField;

        public int ValueProperty { get; set; }

        public static SerializableOnly CreateInstance()
        {
            return new SerializableOnly { ValueField = 10 , ValueProperty = 20 };
        }

        public void AssertEquality(object other)
        {
            Assert.IsNotNull(other);
            Assert.IsInstanceOfType<SerializableOnly>(other);
            SerializableOnly target = other as SerializableOnly;

            Assert.AreEqual(this.ValueField, target.ValueField);
            Assert.AreEqual(this.ValueProperty, target.ValueProperty);
        }
    }
}
