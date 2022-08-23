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
		private readonly IDictionary<string, AkChunkBase> chunks;

		public string BankName { get; }

		public AkSoundBank(string bankName = "") : base()
		{
			BankName = bankName;
			chunks = new AkChunkBase[]
			{
				new AkBKHD(this)
			}.ToDictionary(chunk => chunk.Header.Text.ToLower(), chunk => chunk);
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

			if (AkChunkType.AKBK.ChunkHeader == header)
			{
				reader.ReadGAP(DataType.TYPE_U32);
				reader.GuessEndianness(0x10);
				header = reader.Peek4CC();
			}

			if (AkChunkType.BKHD.ChunkHeader != header)
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

			AkChunkBase chunk = this[header];
			if (chunk is null)
			{
				reader.Seek(nextChunk);
				return;
			}

			chunk.Visit(reader);
			reader.Seek(nextChunk);
		}
		#endregion

		public AkChunkBase this[FourCC header]
		{
			get
			{
				if (chunks.TryGetValue(header, out AkChunkBase chunk))
				{
					return chunk;
				}
				return null;
			}
		}
	}
}
