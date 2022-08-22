using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AkWWISE.Core.Nodes
{
	public abstract class NodeElement : IEnumerable<KeyValuePair<string, object>>
	{
		#region Fields and Properties
		private readonly IDictionary<string, object> values = new Dictionary<string, object>();

		protected readonly List<NodeElement> children = new List<NodeElement>();

		public NodeElement Parent { get; protected set; }

		public IList<NodeElement> Children => children.AsReadOnly();

		public string NodeName { get; protected set; }
		#endregion

		#region Indexer
		public object this[string key]
		{
			get => Get<object>(key);
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
		public void Append(NodeElement node)
		{
			if (node is null)
			{
				return;
			}
			children.Add(node);
		}

		#region Data Handling 
		public bool ContainsKey(string key) => values.ContainsKey(key);

		public bool TryGet<T>(string key, out T value)
		{
			if (values.TryGetValue(key, out object result))
			{
				value = (T)result;
				return true;
			}
			value = default;
			return false;
		}

		public T Get<T>(string key) => (T)values[key];

		public T Set<T>(string key, T value)
		{
			if (ContainsKey(key))
			{
				values[key] = value;
			}
			else
			{
				values.Add(key, value);
			}
			return value;
		}

		public IDictionary<string, object> ToDictionary() => new ReadOnlyDictionary<string, object>(values);

		#region Interface Implementations
		#region IEnumerator<KeyValuePair<string, object>>
		public IEnumerator<KeyValuePair<string, object>> GetEnumerator() => values.GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		#endregion
		#endregion
		#endregion
		#endregion
	}
}
