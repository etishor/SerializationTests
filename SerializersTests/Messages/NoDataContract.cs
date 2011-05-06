using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;

namespace SerializersTests.Messages
{
    public class NoDataContractOnly : IAssertEquality
    {
        public int ValueField;

        public int ValueProperty { get; set; }

        public static NoDataContractOnly CreateInstance()
        {
            return new NoDataContractOnly { ValueField = 10, ValueProperty = 20 };
        }

        public void AssertEquality(object other)
        {
            Assert.IsNotNull(other);
            Assert.IsInstanceOfType<NoDataContractOnly>(other);
            NoDataContractOnly target = other as NoDataContractOnly;

            Assert.AreEqual(this.ValueField, target.ValueField);
            Assert.AreEqual(this.ValueProperty, target.ValueProperty);
        }
    }
}
