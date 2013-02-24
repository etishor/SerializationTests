
namespace SerializersTests.Adapters
{

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class MsgPackBoxingPackerAdapter : ISerializerAdapter
    {
        private readonly MsgPack.BoxingPacker packer = new MsgPack.BoxingPacker();

		public void Serialize(System.IO.Stream stream, object instance)
		{
			packer.Pack(stream, instance);
		}

		public object Deserialize(System.IO.Stream stream, System.Type type)
		{
			return packer.Unpack(stream);
		}
	}

    public class MsgPackCompiledPackerAdapter : ISerializerAdapter
    {
        private readonly MsgPack.CompiledPacker packer = new MsgPack.CompiledPacker(true);

		public void Serialize(System.IO.Stream stream, object instance)
		{
			packer.Pack(stream, instance);
		}

		public object Deserialize(System.IO.Stream stream, System.Type type)
		{
			return packer.Unpack(type,stream);
		}
	}

    public class MsgPackObjectPackerAdapter : ISerializerAdapter
    {
        private readonly MsgPack.ObjectPacker packer = new MsgPack.ObjectPacker();

		public void Serialize(System.IO.Stream stream, object instance)
		{
			packer.Pack(stream, instance);
		}

		public object Deserialize(System.IO.Stream stream, System.Type type)
		{
			return packer.Unpack(type,stream);
		}
	}
}
