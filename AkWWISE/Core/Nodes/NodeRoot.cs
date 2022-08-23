namespace AkWWISE.Core.Nodes
{
	public abstract class NodeRoot<TRoot> : NodeObject<TRoot>
	where TRoot : NodeRoot<TRoot>
	{
		protected NodeRoot() : base()
		{
		}

		protected NodeRoot(string name) : base(name, null)
		{
		}
	}
}
