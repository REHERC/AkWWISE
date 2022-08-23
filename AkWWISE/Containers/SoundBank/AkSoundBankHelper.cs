#pragma warning disable CA1822, IDE0063

using System.IO;
using AkWWISE.IO;

namespace AkWWISE.Containers.SoundBank
{
	public class AkSoundBankHelper
	{
		public AkSoundBank LoadFrom(FileInfo file)
		{
			if (!file.Exists)
			{
				throw new FileNotFoundException("The SoundBank file does not exist.", file.FullName);
			}

			using (Stream stream = File.OpenRead(file.FullName))
			{
				return LoadFrom(stream, Path.GetFileNameWithoutExtension(file.FullName));
			}
		}

		public AkSoundBank LoadFrom(Stream stream, string bankName = "")
		{
			AkSoundBank result = new AkSoundBank(bankName);
			using (AkBinaryReader reader = new AkBinaryReader(stream))
			{
				result.Visit(reader);
			}
			return result;
		}
	}
}
