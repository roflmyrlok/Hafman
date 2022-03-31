using System.Collections.Generic;
using System.Xml.Serialization;

namespace Havman
{
	public class TxtLinesToFrequencyDict
	{
		public Dictionary<char, int> CharFrequencyDictionary { get; }

		public  TxtLinesToFrequencyDict(List<string> lines)
		{
			CharFrequencyDictionary = new Dictionary<char, int>();
			foreach (var element in lines)
			{
				var charsInLine = element.ToCharArray();
				foreach (var chara in charsInLine)
				{
					if (CharFrequencyDictionary.ContainsKey(chara))
					{
						CharFrequencyDictionary[chara] += 1;
					}
					else
					{
						CharFrequencyDictionary.Add(chara, 1);
					}
				}
			}
		}
	}
}