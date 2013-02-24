
using NServiceBus;
namespace SerializersTests
{
    /// <summary>
    /// Interface that message must implement to support automatic test generation.
    /// In real live applications serializable objects should not implement such interface
    /// </summary>
    /// <remarks>
    /// The IMessage interface is just for the NServiceBus Serializers
    /// </remarks>
    public interface IAssertEquality : IMessage
    {
        /// <summary>
        /// Asserts on the equality of this instance with the other object.
        /// </summary>
        /// <remarks>
        /// The other object is the deserialized form of the object.
        /// </remarks>
        /// <param name="other">The deserialized object.</param>
        void AssertEquality(object other);
    }
}
