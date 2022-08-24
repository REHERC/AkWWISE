using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AkWWISE.Cli.Services;
using AkWWISE.Containers.SoundBank;
using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;

namespace AkWWISE.Cli.Commands.Dump
{
	[Command("soundbank", Description = "Load one or more WWISE .bnk soundbanks")]
	public class SoundBankCommand : ICommand
	{
		#region Command Parameters and Options
		[CommandOption("folders", 'f', Description = "Indicates if the paths specified are folders instead of files")]
		public bool ScanFolders { get; set; }
		
		[CommandParameter(0, IsRequired = true, Name = "items", Description = "Location of the files to be loaded")]
		public IReadOnlyList<string> Items { get; set; }

		public IEnumerable<FileInfo> Files
		=> ScanFolders
			? Items.SelectMany(item => new DirectoryInfo(item).GetFiles("*.bnk"))
			: Items.Select(item => new FileInfo(item));
		#endregion

		protected static readonly NodePrinter printer = new NodePrinter();

		public ValueTask ExecuteAsync(IConsole console)
		{
			AkSoundBankHelper helper = new AkSoundBankHelper();

			List<AkSoundBank> soundbanks = Files
				.Select(file => helper.LoadFrom(file))
				.ToList();

			foreach (AkSoundBank soundbank in soundbanks)
			{
				string hierarchy = printer.GetString(soundbank);
				console.Output.WriteLine(hierarchy);
			}

			return default;
		}
	}
}
