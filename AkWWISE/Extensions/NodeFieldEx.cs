#pragma warning disable CA1050

using AkWWISE.Core.Nodes;

public static class NodeFieldEx
{
	public static NodeField<int> Bit(this NodeField<int> field, string name, int offset, int mask = 0xFFFF)
	{
		field.Append(name, new NodeField<int>((field.Value >> offset) & mask));
		return field;
	}

	public static NodeField<uint> Bit(this NodeField<uint> field, string name, int offset, int mask = 0xFFFF)
	{
		field.Append(name, new NodeField<uint>((uint)((field.Value >> offset) & mask)));
		return field;
	}
}