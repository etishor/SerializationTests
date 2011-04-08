using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Reflection;
using NServiceBus;

namespace SerializersTests
{
    public interface IAssertEquality : IMessage
    {
        void AssertEquality(object other);
    }
}
