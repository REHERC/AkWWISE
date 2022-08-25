using System;
using System.Collections.Generic;
using System.Linq;

namespace AkWWISE.Core.Nodes
{
	public class NodeList<TElement> : NodeElement, IEnumerable<TElement>
	where TElement : NodeElement
	{
		protected List<TElement> Items
		=> base.Children
		.OfType<TElement>()
		.ToList();

		public new IList<TElement> Children => Items.AsReadOnly();

		public NodeList(Func<TElement> provider, int count = 0, NodeElement parent = null)
		: base(nameof(TElement), parent)
		{
			NodeName = $"{typeof(TElement).Name}[]";

			for (int i = 0; i < count; ++i)
			{
				Append($"{i}", provider());
			}
		}

		IEnumerator<TElement> IEnumerable<TElement>.GetEnumerator()
		=> Children.GetEnumerator();

		public override string ToNodeString() => $"{NodeName} ({Children.Count})";

		public static implicit operator List<TElement>(NodeList<TElement> instance) => instance.Items;
	}
}
