using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace AkWWISE.Core.Nodes
{
	public abstract class NodeElement : IEnumerable<KeyValuePair<string, NodeElement>>
	{
		#region Fields and Properties
		private readonly IDictionary<string, NodeElement> values = new Dictionary<string, NodeElement>();

		public NodeElement Parent { get; protected set; }

		public IList<NodeElement> Children => values.Values.ToList().AsReadOnly();

		public string NodeName { get; protected set; }
		#endregion

		#region Indexer
		public NodeElement this[string key]
		{
			get => Get(key);
			set => Set(key, value);
		}
		#endregion

		#region Constructors
		protected NodeElement(NodeElement parent = null)
		: this(null, parent)
		{
			NodeName = GetType().Name;
		}

		protected NodeElement(string name, NodeElement parent = null)
		{
			NodeName = name;
			Parent = parent;
		}
		#endregion

		#region Methods
		public void Append(string name, NodeElement node)
		{
			if (node is null)
			{
				return;
			}

			Set(name, node);
		}
		#region Data Handling 
		public bool ContainsKey(string key) => values.ContainsKey(key);

		public bool TryGet(string key, out NodeElement value)
		{
			if (values.TryGetValue(key, out NodeElement result))
			{
				value = result;
				return true;
			}
			value = default;
			return false;
		}

		public NodeElement Get(string key) => values[key];

		public NodeElement Set<T>(string key, T value)
		{
			NodeElement node = value is NodeElement nodeElement
				? nodeElement
				: new NodeField<T>(value);

			if (ContainsKey(key))
			{
				values[key] = node;
			}
			else
			{
				values.Add(key, node);
			}
			return node;
		}

		public IDictionary<string, NodeElement> ToDictionary() => new ReadOnlyDictionary<string, NodeElement>(values);

		#region Interface Implementations
		#region IEnumerator<KeyValuePair<string, NodeElement>>
		public IEnumerator<KeyValuePair<string, NodeElement>> GetEnumerator() => values.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		#endregion
		#endregion
		#endregion
		#endregion
	}
}
