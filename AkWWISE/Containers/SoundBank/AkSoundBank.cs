using AkWWISE.Core.Model.Nodes;
using AkWWISE.IO.Interfaces;

namespace AkWWISE.Containers.SoundBank
{
    public class AkSoundBank : NodeRoot<AkSoundBank>
	{
		public string BankName { get; }

		public AkSoundBank(string bankName = "") : base()
		{
			BankName = bankName;
		}

		public override void Visit(IReader reader)
		{
			throw new System.NotImplementedException();
		}
	}
}
