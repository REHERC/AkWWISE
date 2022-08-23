#pragma warning disable CA1050

using AkWWISE.Core.DataStruct;
using AkWWISE.IO.Interfaces;

public static class ReaderEx
{
	public static FourCC Peek4CC(this IReader reader)
	{
		reader.PushOffset();
		FourCC header = reader.Read4CC();
		reader.PopOffset();
		return header;
	}
}