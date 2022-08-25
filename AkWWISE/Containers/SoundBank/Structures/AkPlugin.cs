using AkWWISE.Core.Nodes;
using AkWWISE.IO.Interfaces;

namespace AkWWISE.Containers.SoundBank.Structures
{
	public class AkPlugin : AkSoundBankObject
	{
		public string DLLName => GetField<string>("pDLLName");

		public AkPlugin(NodeObject<AkSoundBank> parent) : base(parent)
		{
		}

		public override void Visit(IReader reader)
		{
			this.U32("id", reader);
			if (AkVersion <= 136)
			{
				uint strSize = this.U32("uStringSize", reader);
				this.STR("pDLLName", (int)strSize, reader);
			}
			else
			{
				this.STZ("pDLLName", reader);
			}
		}
	}
}
