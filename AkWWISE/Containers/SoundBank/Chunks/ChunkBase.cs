using AkWWISE.Core.DataStruct;
using AkWWISE.Core.Nodes;
using AkWWISE.IO.Interfaces;

namespace AkWWISE.Containers.SoundBank.Chunks
{
	public abstract class ChunkBase : AkSoundBankObject
	{
		#region Properties
		public abstract ChunkType Type { get; }

		public FourCC Header => Type.Header;

		public string Name => Type.Name;

		public string Description => Type.FriendlyName;

		public uint Length { get; private set; }
		#endregion

		public ChunkBase(AkSoundBank parent)
		: base(parent)
		{
		}

		public override void Visit(IReader reader)
		{
			Length = reader.ReadU32();
		}

		public override string ToNodeString() => $"{NodeName} ({Length} bytes) - {Type.FriendlyName}";
	}
}
