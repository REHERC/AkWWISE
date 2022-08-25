using System.Collections.Generic;
using AkWWISE.Containers.SoundBank.Structures;
using AkWWISE.IO.Interfaces;

namespace AkWWISE.Containers.SoundBank.Chunks
{
	public class AkINIT : ChunkBase
	{
		#region Initialization
		public override ChunkType Type => ChunkType.INIT;

		public AkINIT(AkSoundBank parent) : base(parent)
		{
		}
		#endregion

		#region Properties
		public List<AkPlugin> Plugins => GetList<AkPlugin>("pAkPluginList");
		#endregion

		public override void Visit(IReader reader)
		{
			base.Visit(reader);

			uint count = this.U32("count", reader);
			foreach (AkPlugin plugin in List("pAkPluginList", (int)count, () => new AkPlugin(this)))
			{
				plugin.Visit(reader);
			}
		}
	}
}
