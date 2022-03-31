using System.Collections.Generic;
using System.Xml.Serialization;

namespace Havman
{
	public class FrequencyAnalyzer
	{
		public Dictionary<char,int> AnalyzeFrequency (List<string> lines)
		{
			var charFrequency = new Dictionary<char, int>();
			foreach (var element in lines)
			{
				var charsInLine = element.ToCharArray();
				foreach (var chara in charsInLine)
				{
					if (charFrequency.ContainsKey(chara))
					{
						charFrequency[chara] += 1;
					}
					else
					{
						charFrequency.Add(chara, 1);
					}
				}
			}
			return charFrequency;
		}
	}
}