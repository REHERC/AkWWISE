using AkWWISE.Core.Nodes;
using AkWWISE.IO.Interfaces;

namespace AkWWISE.Containers.SoundBank.Structures
{
	public class AkMediaIndex : AkSoundBankObject
	{
		public uint Id => GetField<uint>("id");

		public uint Offset => GetField<uint>("uOffset");

		public uint Size => GetField<uint>("uSize");

		public AkMediaIndex(NodeObject<AkSoundBank> parent) : base(parent)
		{
		}

		public override void Visit(IReader reader)
		{
			this.SID("id", reader);
			this.U32("uOffset", reader);
			this.U32("uSize", reader);
		}
	}
}
