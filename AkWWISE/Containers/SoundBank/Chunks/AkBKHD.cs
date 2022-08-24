using AkWWISE.IO.Interfaces;

namespace AkWWISE.Containers.SoundBank.Chunks
{
	public class AkBKHD : ChunkBase
	{
		#region Initialization
		public override ChunkType Type => ChunkType.BKHD;

		public AkBKHD(AkSoundBank parent) : base(parent)
		{
		}
		#endregion

		#region Overrides
		public override uint AkVersion => GetField<uint>("akVersion");
		#endregion

		public override void Visit(IReader reader)
		{
			base.Visit(reader);

			this.U32("akVersion", reader);
			this.U32("akId", reader);

			if (AkVersion <= 26)
			{
				this.U32("bInitializationBank", reader);
				this.U32("unknown", reader);
				this.U32("dwBankGeneratorVersion", reader);
			}
			else
			{
				this.U32("dwBankGeneratorVersion", reader);
				this.SID("dwSoundBankID", reader);
			}

			if (AkVersion <= 122)
			{
				this.U32("dwLanguageID", reader);
			}
			else
			{
				this.SID("dwLanguageID", reader);
			}

			if (AkVersion <= 26)
			{
				this.U64("qwTimestamp", reader);
			}
			else if (AkVersion <= 126)
			{
				this.U32("bFeedbackInBank", reader);
			}
			else if (AkVersion <= 134)
			{
				this.U32("uAltValues", reader)
					.Bit("uAlignment", 0x00)
					.Bit("bDeviceAllocated", 0x10);
			}
			else
			{
				this.U32("uAltValues", reader)
					.Bit("bUnused", 0x00)
					.Bit("bDeviceAllocated", 0x10);
			}

			if (AkVersion <= 76)
			{
				U32("dwProjectID", 0);
			}
			else
			{
				this.U32("dwProjectID", reader);
			}

			if (AkVersion > 140)
			{
				this.U32("dwSoundBankType", reader);
				this.GAP("abyBankHash", 0x10, reader);
			}

			uint padding;
			if (AkVersion <= 26)
			{
				padding = Length - 0x18;
			}
			else if (AkVersion <= 76)
			{
				padding = Length - 0x10;
			}
			else if (AkVersion <= 140)
			{
				padding = Length - 0x14;
			}
			else
			{
				padding = Length - 0x28;
			}

			this.GAP("padding", (int)padding, reader);
		}
	}
}
