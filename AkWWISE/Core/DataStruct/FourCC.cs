using System;
using System.Linq;
using System.Text;

namespace AkWWISE.Core.DataStruct
{
	public class FourCC : CharChain
	{
		#region Constants
		public const int STRUCT_SIZE = 4;
		#endregion

		#region Fields & Properties
		public int Code => ((Bytes[0] << 24) | (Bytes[1] << 16) | (Bytes[2] << 8) | Bytes[3]);
		#endregion

		#region Constructors
		public FourCC(string value)
		: base (value, STRUCT_SIZE)
		{
		}

		public FourCC(byte[] value)
		: base(value, STRUCT_SIZE)
		{
		}

		public FourCC(byte a, byte b, byte c, byte d)
		: base(new byte[4] { a, b, c, d })
		{
		}
		#endregion

		#region Override Methods (System.Object)
		public override bool Equals(object obj)
		=> obj is FourCC cC
		&& Bytes.SequenceEqual(cC.Bytes);

		public override int GetHashCode()
		=> Code;
		#endregion

		#region Operators
		#region Base Operators
		public static bool operator ==(FourCC a, FourCC b) => a.Equals(b);
		public static bool operator !=(FourCC a, FourCC b) => !a.Equals(b);
		#endregion
		#endregion
	}
}
