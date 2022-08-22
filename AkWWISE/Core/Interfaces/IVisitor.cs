using AkWWISE.IO.Interfaces;

namespace AkWWISE.Core.Interfaces
{
    public interface IVisitor
	{
		void Visit(IReader reader);
	}
}
