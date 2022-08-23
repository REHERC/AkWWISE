using AkWWISE.Core.DataStruct;
using AkWWISE.Core.Nodes;
using AkWWISE.IO.Interfaces;

namespace AkWWISE.Containers.SoundBank.Chunks
{
	public abstract class AkChunkBase : NodeObject<AkSoundBank>
	{
		#region Properties
		public abstract AkChunkType Type { get; }

		public FourCC Header => Type.ChunkHeader;

		public string Name => Type.Name;

		public string Description => Type.FriendlyName;

		public int Length => GetField<int>("akLength");
		#endregion

		public AkChunkBase(AkSoundBank parent)
		: base(parent)
		{
		}

		public override void Visit(IReader reader)
		{
			this.U32("akLength", reader);
		}
	}
}
