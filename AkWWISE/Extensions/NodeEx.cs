#pragma warning disable CA1050

using AkWWISE.Core.DataStruct;
using AkWWISE.Core.Nodes;
using AkWWISE.IO.Interfaces;

public static class NodeEx
{
	#region Data handling
	public static NodeField<double> D64<T>(this NodeObject<T> node, string name, IReader reader)
	where T : NodeRoot<T>
	=> node.D64(name, reader.ReadD64());

	public static NodeField<float> F32<T>(this NodeObject<T> node, string name, IReader reader)
	where T : NodeRoot<T>
	=> node.F32(name, reader.ReadF32());

	public static NodeField<long> S64<T>(this NodeObject<T> node, string name, IReader reader)
	where T : NodeRoot<T>
	=> node.S64(name, reader.ReadS64());

	public static NodeField<ulong> U64<T>(this NodeObject<T> node, string name, IReader reader)
	where T : NodeRoot<T>
	=> node.U64(name, reader.ReadU64());

	public static NodeField<int> S32<T>(this NodeObject<T> node, string name, IReader reader)
	where T : NodeRoot<T>
	=> node.S32(name, reader.ReadS32());

	public static NodeField<uint> U32<T>(this NodeObject<T> node, string name, IReader reader)
	where T : NodeRoot<T>
	=> node.U32(name, reader.ReadU32());

	public static NodeField<short> S16<T>(this NodeObject<T> node, string name, IReader reader)
	where T : NodeRoot<T>
	=> node.S16(name, reader.ReadS16());

	public static NodeField<ushort> U16<T>(this NodeObject<T> node, string name, IReader reader)
	where T : NodeRoot<T>
	=> node.U16(name, reader.ReadU16());

	public static NodeField<sbyte> S8<T>(this NodeObject<T> node, string name, IReader reader)
	where T : NodeRoot<T>
	=> node.S8(name, reader.ReadS8());

	public static NodeField<byte> U8<T>(this NodeObject<T> node, string name, IReader reader)
	where T : NodeRoot<T>
	=> node.U8(name, reader.ReadU8());

	public static NodeField<byte[]> GAP<T>(this NodeObject<T> node, string name, int bytes, IReader reader)
	where T : NodeRoot<T>
	=> node.GAP(name, reader.ReadGAP(bytes));

	public static NodeField<FourCC> FourCC<T>(this NodeObject<T> node, string name, IReader reader)
	where T : NodeRoot<T>
	=> node.FourCC(name, reader.Read4CC());

	public static NodeField<uint> SID<T>(this NodeObject<T> node, string name, IReader reader)
	where T : NodeRoot<T>
	=> node.U32(name, reader);

	public static NodeField<uint> TID<T>(this NodeObject<T> node, string name, IReader reader)
	where T : NodeRoot<T>
	=> node.SID(name, reader);

	public static NodeField<string> STR<T>(this NodeObject<T> node, string name, int length, IReader reader)
	where T : NodeRoot<T>
	=> node.STR(name, reader.ReadSTR(length));

	public static NodeField<string> S32STR<T>(this NodeObject<T> node, string name, IReader reader)
	where T : NodeRoot<T>
	=> node.STR(name, reader.ReadS32(), reader);

	public static NodeField<string> STZ<T>(this NodeObject<T> node, string name, IReader reader)
	where T : NodeRoot<T>
	=> node.STR(name, reader.ReadSTZ());
	#endregion
}