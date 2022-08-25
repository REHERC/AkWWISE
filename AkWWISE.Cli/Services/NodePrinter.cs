using System;
using System.Collections.Generic;
using System.Text;
using AkWWISE.Core.Nodes;

namespace AkWWISE.Cli.Services
{
	public class NodePrinter
	{
		public static readonly Type NODE_FIELD = typeof(NodeField<>);

		public string GetString(NodeElement node)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(node.ToNodeString());
			Print(sb, node);
			return sb.ToString();
		}

		protected void Print(StringBuilder sb, NodeElement node, int depth = 0)
		{
			void Write(string text, bool newLine = true)
			{
				sb.Append(' ', 2 * depth);
				if (newLine)
				{
					sb.AppendLine(text);
				}
				else
				{
					sb.Append(text);
				}
			}

			Func<string, string, string> formatter = FormatNodeName;
			Type nodeType = node.GetType();
			if (nodeType.IsSubClassOfRawGeneric(typeof(NodeList<>)))
			{
				formatter = FormatListEntryName;
			}

			foreach (KeyValuePair<string, NodeElement> property in node)
			{
				string name = property.Key;
				NodeElement subNode = property.Value;
				string value = subNode.ToNodeString();

				Write(formatter(name, value));

				Print(sb, subNode, depth + 1);
			}
		}

		protected string FormatNodeName(string name, string value) => $"- {name}: {value}";

		protected string FormatListEntryName(string name, string value) => $"[{name}] {value}";
	}
}
