using AkWWISE.IO.Interfaces;

namespace AkWWISE.Containers.SoundBank.Chunks
{
	public class AkPLAT : ChunkBase
	{
		#region Initialization
		public override ChunkType Type => ChunkType.PLAT;

		public AkPLAT(AkSoundBank parent) : base(parent)
		{
		}
		#endregion

		#region Properties
		public string CustomPlatformName => GetField<string>("pCustomPlatformName");
		#endregion

		public override void Visit(IReader reader)
		{
			base.Visit(reader);

			if (AkVersion <= 136)
			{
				this.S32STR("pCustomPlatformName", reader);
			}
			else
			{
				this.STZ("pCustomPlatformName", reader);
			}
		}
	}
}
