using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MbUnit.Framework;

namespace SerializersTests.Messages
{
    public sealed class SealedPublicReadOnlyNamesInConstructorNoAttributes : IAssertEquality
    {
        public readonly int IntValue;

        public SealedPublicReadOnlyNamesInConstructorNoAttributes(int intValue)
        {
            this.IntValue = intValue;
        }

        public static SealedPublicReadOnlyNamesInConstructorNoAttributes CreateInstance()
        {
            return new SealedPublicReadOnlyNamesInConstructorNoAttributes(10);
        }

        public void AssertEquality(object other)
        {
            Assert.IsNotNull(other);
            Assert.IsInstanceOfType<SealedPublicReadOnlyNamesInConstructorNoAttributes>(other);

            SealedPublicReadOnlyNamesInConstructorNoAttributes target = other as SealedPublicReadOnlyNamesInConstructorNoAttributes;

            Assert.AreEqual(this.IntValue, target.IntValue);            
        }
    }
}
