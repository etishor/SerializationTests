
namespace SerializersTests.Adapters
{

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class MsgPackBoxingPackerAdapter : ISerializerAdapter
    {
        private readonly MsgPack.BoxingPacker packer = new MsgPack.BoxingPacker();

        public void Serialize<T>(System.IO.Stream stream, T instance)
        {
            packer.Pack(stream, instance);
        }

        public T Deserialize<T>(System.IO.Stream stream)
        {
            return (T)packer.Unpack(stream);
        }
    }

    public class MsgPackCompiledPackerAdapter : ISerializerAdapter
    {
        private readonly MsgPack.CompiledPacker packer = new MsgPack.CompiledPacker(true);

        public void Serialize<T>(System.IO.Stream stream, T instance)
        {
            packer.Pack(stream, instance);
        }

        public T Deserialize<T>(System.IO.Stream stream)
        {
            return packer.Unpack<T>(stream);
        }
    }

    public class MsgPackObjectPackerAdapter : ISerializerAdapter
    {
        private readonly MsgPack.ObjectPacker packer = new MsgPack.ObjectPacker();

        public void Serialize<T>(System.IO.Stream stream, T instance)
        {
            packer.Pack(stream, instance);
        }

        public T Deserialize<T>(System.IO.Stream stream)
        {
            return packer.Unpack<T>(stream);
        }
    }
}
