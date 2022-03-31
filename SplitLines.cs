using System.Collections.Generic;
using System.Xml.Serialization;

namespace Havman
{
	public class SplitLines
	{
		public SplitLines()
		{
			Charnumber = new Dictionary<char, int>();
		}
		public Dictionary<char, int> Charnumber { get; }

		public void splitNFill(List<string> lines)
		{
			foreach (var element in lines)
			{
				var charsInLine = element.ToCharArray();
				foreach (var chara in charsInLine)
				{
					if (Charnumber.ContainsKey(chara))
					{
						Charnumber[chara] += 1;
					}
					else
					{
						Charnumber.Add(chara, 1);
					}
				}
			}
		}
	}
}