using System.Collections.Generic;
using System.IO;
using System.Linq;
using AkWWISE.Containers.SoundBank.Chunks;
using AkWWISE.Core;
using AkWWISE.Core.DataStruct;
using AkWWISE.Core.Nodes;
using AkWWISE.IO.Interfaces;

namespace AkWWISE.Containers.SoundBank
{
	public class AkSoundBank : NodeRoot<AkSoundBank>
	{
		#region Properties and Fields
		private readonly IDictionary<string, ChunkBase> chunks;

		public string BankName { get; }
		#endregion

		#region Chunks
		public AkBKHD BKHD => GetChunk<AkBKHD>(ChunkType.BKHD);

		public AkPLAT PLAT => GetChunk<AkPLAT>(ChunkType.PLAT);
		#endregion

		public AkSoundBank(string bankName = "") : base()
		{
			BankName = bankName;
			chunks = new ChunkBase[]
			{
				new AkBKHD(this),
				new AkPLAT(this)
			}.ToDictionary(chunk => chunk.Header.Text, chunk => chunk);
		}

		#region Visit
		public override void Visit(IReader reader)
		{
			VisitFileHeader(reader);
			VisitChunks(reader);
		}

		protected void VisitFileHeader(IReader reader)
		{
			FourCC header = reader.Peek4CC();

			if (ChunkType.AKBK.Header == header)
			{
				reader.ReadGAP(DataType.TYPE_U32);
				reader.GuessEndianness(0x10);
				header = reader.Peek4CC();
			}

			if (ChunkType.BKHD.Header != header)
			{
				throw new InvalidDataException("Unable to find BKHD header.");
			}
		}

		protected void VisitChunks(IReader reader)
		{
			while (!reader.IsEOF())
			{
				VisitChunk(reader);
			}
		}

		protected void VisitChunk(IReader reader)
		{
			FourCC header = reader.Read4CC(); // Find chunk type

			reader.PushOffset();
			uint length = reader.ReadU32();
			reader.PopOffset();

			long nextChunk = reader.Position + length + sizeof(uint);

			ChunkBase chunk = this[header];
			if (chunk is null)
			{
				reader.Seek(nextChunk);
				return;
			}

			Set(chunk.Header, chunk);
			chunk.Visit(reader);
			reader.Seek(nextChunk);
		}
		#endregion

		public override string ToNodeString() => $"{NodeName} ({BankName})";

		public TChunk GetChunk<TChunk>(FourCC header)
		where TChunk : ChunkBase
		{
			if (chunks.TryGetValue(header, out ChunkBase chunk))
			{
				return chunk as TChunk;
			}
			return null;
		}

		public ChunkBase this[FourCC header] => GetChunk<ChunkBase>(header);
	}
}
