using System.Collections.Generic;
using System.Linq;
using AkWWISE.Core.DataStruct;
using AkWWISE.Core.Interfaces;
using AkWWISE.Core.Nodes;
using AkWWISE.IO.Interfaces;

namespace AkWWISE.Core.Model.Nodes
{
	public abstract class NodeObject<TRoot> : NodeElement, IEnumerable<KeyValuePair<string, NodeElement>>, IVisitor
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
		public void Append(string name, NodeObject<TRoot> node)
		=> base.Append(name, node);

		public abstract void Visit(IReader reader);
		#endregion

		#region Field Append
		public NodeField<byte[]> GAP(string name, byte[] value)
		=> Field(name, value);

		public NodeField<string> STR(string name, string value)
		=> Field(name, value);

		public NodeField<string> STZ(string name, string value)
		=> STR(name, value);

		public NodeField<double> D64(string name, double value)
		=> Field(name, value);

		public NodeField<float> F32(string name, float value)
		=> Field(name, value);

		public NodeField<long> S64(string name, long value)
		=> Field(name, value);

		public NodeField<ulong> U64(string name, ulong value)
		=> Field(name, value);

		public NodeField<int> S32(string name, int value)
		=> Field(name, value);

		public NodeField<uint> U32(string name, uint value)
		=> Field(name, value);

		public NodeField<short> S16(string name, short value)
		=> Field(name, value);

		public NodeField<ushort> U16(string name, ushort value)
		=> Field(name, value);

		public NodeField<sbyte> S8(string name, sbyte value)
		=> Field(name, value);

		public NodeField<byte> U8(string name, byte value)
		=> Field(name, value);

		public NodeField<FourCC> FCC(string name, FourCC value)
		=> Field(name, value);

		public NodeField<uint> SID(string name, uint value)
		=> U32(name, value);

		public NodeField<uint> TID(string name, uint value)
		=> SID(name, value);

		protected NodeField<T> Field<T>(string name, T value)
		=> Set(name, value) as NodeField<T>;
		#endregion
	}
}
