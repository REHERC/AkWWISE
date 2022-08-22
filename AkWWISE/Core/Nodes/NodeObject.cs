using System.Collections.Generic;
using System.Linq;
using AkWWISE.Core.Interfaces;
using AkWWISE.Core.Nodes;
using AkWWISE.IO.Interfaces;

namespace AkWWISE.Core.Model.Nodes
{
	public abstract class NodeObject<TRoot> : NodeElement, IEnumerable<KeyValuePair<string, object>>, IVisitor
	where TRoot : NodeRoot<TRoot>
	{
		#region Fields and Properties		
		public new NodeObject<TRoot> Parent 
		{
			get => base.Parent as NodeObject<TRoot>;
			protected set => base.Parent = value; 
		}

		public TRoot Root { get; protected set; }

		public new IList<NodeObject<TRoot>> Children 
		=> base.Children
		.OfType<NodeObject<TRoot>>()
		.Cast<NodeObject<TRoot>>()
		.ToList();
		#endregion

		#region Constructors
		protected NodeObject(NodeObject<TRoot> parent = null)
		: this(null, parent)
		{
		}

		protected NodeObject(string name, NodeObject<TRoot> parent = null)
		: base(name)
		{
			Parent = parent;

			if (Parent is null)
			{
				Parent = this;
				if (this is TRoot root)
				{
					Root = root;
				}
			}
			else
			{
				Root = Parent.Root;
			}
		}
		#endregion

		#region Methods
		public void Append(NodeObject<TRoot> node)
		=> base.Append(node);

		public abstract void Visit(IReader reader);
		#endregion
	}
}
