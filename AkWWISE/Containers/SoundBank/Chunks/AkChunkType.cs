using AkWWISE.Core.DataStruct;
using Ardalis.SmartEnum;

namespace AkWWISE.Containers.SoundBank.Chunks
{
	public sealed class AkChunkType : SmartEnum<AkChunkType>
	{
		public static readonly AkChunkType
			AKBK = new AkChunkType(0, nameof(AKBK), "Audiokinetic Bank"),
			BKHD = new AkChunkType(1, nameof(BKHD), "Bank Header"),
			HIRC = new AkChunkType(2, nameof(HIRC), "Hierarchy"),
			DATA = new AkChunkType(3, nameof(DATA), "Data"),
			STMG = new AkChunkType(4, nameof(STMG), "Global Settings"),
			DIDX = new AkChunkType(5, nameof(DIDX), "Media Index"),
			FXPR = new AkChunkType(6, nameof(FXPR), "FX Parameters"),
			ENVS = new AkChunkType(7, nameof(ENVS), "Environment Settings"),
			STID = new AkChunkType(8, nameof(STID), "String Mappings"),
			PLAT = new AkChunkType(9, nameof(PLAT), "Custom Platform"),
			INIT = new AkChunkType(10, nameof(INIT), "Plugin");

		public string FriendlyName { get; }

		public FourCC ChunkHeader => new FourCC(Name);

		private AkChunkType(int ordinal, string name, string friendlyName)
		: base(name, ordinal)
		=> FriendlyName = friendlyName;
	}
}
