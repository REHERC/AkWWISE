using System.Collections.Generic;
using System.Linq;

namespace AkWWISE.Core.Nodes
{
	public class NodeList<TElement> : NodeElement, IEnumerable<TElement>
	where TElement : NodeElement
	{
		public const string FIELD_NAME = "list";

		public new IList<TElement> Children
		=> base.Children
		.OfType<TElement>()
		.Cast<TElement>()
		.ToList();

		public NodeList()
		: this(null)
		{
		}

		public NodeList(NodeElement parent = null)
		: base(FIELD_NAME, parent)
		{
		}

		IEnumerator<TElement> IEnumerable<TElement>.GetEnumerator()
		=> Children.GetEnumerator();
	}
}
