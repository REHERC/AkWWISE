using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AkWWISE.Containers.SoundBank;
using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;

namespace AkWWISE.Cli.Commands.Dump
{
	[Command("soundbank", Description = "Load one or more WWISE .bnk soundbanks")]
	public class SoundBankCommand : ICommand
	{
		[CommandParameter(0, IsRequired = true, Name = "files", Description = "Files to be loaded by the tool")]
		public IReadOnlyList<FileInfo> Files { get; set; } 

		public ValueTask ExecuteAsync(IConsole console)
		{
			AkSoundBankHelper helper = new AkSoundBankHelper();

			List<AkSoundBank> soundbanks = Files
				.Select(file => helper.LoadFrom(file))
				.ToList();

			return default;
		}
	}
}
