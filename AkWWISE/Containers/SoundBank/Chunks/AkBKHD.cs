using AkWWISE.IO.Interfaces;

namespace AkWWISE.Containers.SoundBank.Chunks
{
	public class AkBKHD : AkChunkBase
	{
		#region Initialization
		public override AkChunkType Type => AkChunkType.BKHD;

		public AkBKHD(AkSoundBank parent) : base(parent)
		{
		}
		#endregion

		public override void Visit(IReader reader)
		{
			base.Visit(reader);
			System.Console.WriteLine("akBKHD !!!");
		}
	}
}
