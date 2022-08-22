using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AkWWISE.Core.DataStruct
{
	public class CharChain
	{
		#region Fields & Properties
		public static readonly Encoding TextEncoding = Encoding.ASCII;

		private readonly int size;

		private readonly byte[] bytes;

		public byte[] Bytes => bytes;

		public char[] Chars => Bytes.Select(b => (char)b).ToArray();

		public string Text => TextEncoding.GetString(Bytes);

		public int Size => size;
		#endregion

		#region Constructors
		public CharChain(string value, int size)
		{
			this.size = size;
			if (value.Length != size)
			{
				throw new ArgumentException($"Text must be of length of {size}", nameof(value));
			}
			bytes = new CharChain(TextEncoding.GetBytes(value)).bytes;
		}

		public CharChain(byte[] value, int size)
		{
			this.size = size;
			if (value.Length != size)
			{
				throw new ArgumentException("Byte array must have a length of 4", nameof(value));
			}
			bytes = value.Take(size).ToArray();
		}

		public CharChain(byte[] value)
		: this(value, value.Length)
		{
		}
		#endregion

		#region Override Methods (System.Object)
		public override string ToString() => Text;

		public override bool Equals(object obj)
		=> obj is CharChain cC
		&& size == cC.size
		&& bytes.SequenceEqual(cC.bytes);

		public override int GetHashCode()
		=> -119561052 + EqualityComparer<byte[]>.Default.GetHashCode(bytes);
		#endregion

		#region Operators
		#region Type Conversion
		public static implicit operator byte[](CharChain current) => current.Bytes;
		public static implicit operator char[](CharChain current) => current.Chars;
		public static implicit operator string(CharChain current) => current.Text;
		#endregion
		#region Base Operators
		public static bool operator ==(CharChain a, CharChain b) => a.Equals(b);
		public static bool operator !=(CharChain a, CharChain b) => !a.Equals(b);
		#endregion
		#endregion
	}
}
