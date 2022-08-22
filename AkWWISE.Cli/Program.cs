using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using CliFx;

namespace AkWWISE.Cli
{
	internal class Program
	{
		public static async Task<int> Main()
		{
			SetCulture();
			return await new CliApplicationBuilder()
				.SetExecutableName("wwise")
				.SetTitle("AudioKinetic Wave Works Interactive Sound Engine")
				.SetDescription("Utility to inspect WWISE sound banks")
				.AddCommandsFromThisAssembly()
				.Build()
				.RunAsync();
		}

		internal static void SetCulture()
		{
			Thread thread = Thread.CurrentThread;
			thread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
			thread.CurrentUICulture = thread.CurrentCulture;
		}
	}
}