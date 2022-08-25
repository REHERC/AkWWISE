using AkWWISE.Core.Nodes;

namespace AkWWISE.Containers.SoundBank
{
	public abstract class AkSoundBankObject : NodeObject<AkSoundBank>
	{
		public virtual uint AkVersion => Root.BKHD.AkVersion;

		public AkSoundBankObject(NodeObject<AkSoundBank> parent) : base(parent)
		{
		}
	}
}
