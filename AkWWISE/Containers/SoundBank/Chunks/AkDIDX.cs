using System.Collections.Generic;
using AkWWISE.Containers.SoundBank.Structures;
using AkWWISE.Core.Nodes;
using AkWWISE.IO.Interfaces;

namespace AkWWISE.Containers.SoundBank.Chunks
{
	public class AkDIDX : ChunkBase
	{
		#region Initialization
		public override ChunkType Type => ChunkType.DIDX;

		public AkDIDX(AkSoundBank parent) : base(parent)
		{
		}
		#endregion

		#region Properties
		public List<AkMediaIndex> Medias => GetList<AkMediaIndex>("pLoadedMedia");
		#endregion

		public override void Visit(IReader reader)
		{
			base.Visit(reader);

			int count = (int)(Length / 0x10);
			foreach (AkMediaIndex mediaIndex in List("pLoadedMedia", count, () => new AkMediaIndex(this)))
			{
				mediaIndex.Visit(reader);
			}
		}
	}
}
