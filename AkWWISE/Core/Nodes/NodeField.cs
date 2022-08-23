using System.Collections.Generic;

namespace AkWWISE.Core.Nodes
{
	public class NodeField<TData> : NodeElement
	{
		public const string FIELD_NAME = "field";

		public TData Value { get; protected set; }

		public NodeField(TData value)
		: base(FIELD_NAME)
		=> Value = value;

		public override bool Equals(object obj)
		=> obj is NodeField<TData> field
		&& EqualityComparer<TData>.Default.Equals(Value, field.Value);

		public override int GetHashCode()
		=> -1937169414 + EqualityComparer<TData>.Default.GetHashCode(Value);

		public override string ToString() => Value.ToString();

		public static implicit operator TData(NodeField<TData> field) => field.Value;
	}
}
