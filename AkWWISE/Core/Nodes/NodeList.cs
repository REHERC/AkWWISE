using System;
using System.Collections.Generic;
using System.Linq;

namespace AkWWISE.Core.Nodes
{
	public class NodeList<TElement> : NodeElement, IEnumerable<TElement>
	where TElement : NodeElement
	{
		public new IList<TElement> Children
		=> base.Children
		.OfType<TElement>()
		.Cast<TElement>()
		.ToList();

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
	}
}
