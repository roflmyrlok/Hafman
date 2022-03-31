using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Havman
{
	class Program
	{
		static void Main(string[] args)
		{
			var pathToNonCodedTxt = "lines.txt";
			List<string> lines = new FileReader().ReadLines(pathToNonCodedTxt);
			var DictOfFrequency = new TxtLinesToFrequencyDict(lines);
			var queue = new SplitDictToQueue(DictOfFrequency.CharFrequencyDictionary).PriorityQueue;
			var root = new BinaryTreeFromQueueOfFrequencyCreation(queue).root;
			var codeDict = new Dictionary<string, string>();
			var deCodeDict = new Dictionary<string, string>();
			for (int leafs = 0; leafs <= DictOfFrequency.CharFrequencyDictionary.Count; leafs++)
			{
				var newLeaf = findLeaf(root);
				if (newLeaf.Item2 == "") continue; //rem for full data
				codeDict.Add(newLeaf.Item2, newLeaf.Item1);
				deCodeDict.Add(newLeaf.Item1, newLeaf.Item2);
			}

			var newCrypt = "";
			var pathd = @"ans";
			newCrypt += deCodeDict.Count + Environment.NewLine;
			foreach (var VARIABLE in deCodeDict)
			{
				newCrypt += (VARIABLE.Key + " " + VARIABLE.Value + Environment.NewLine);
			}

			foreach (var word in lines)
			{
				var wordCrypt = "";
				foreach (var leter in word)
				{
					wordCrypt += codeDict[leter.ToString()];
				}
				wordCrypt = Convert.ToString(Convert.ToInt32(wordCrypt, 2), 10);
				wordCrypt += Environment.NewLine;
				newCrypt += wordCrypt;
			}

			File.WriteAllText(pathd, newCrypt);
			decoder();

			Tuple<string, string> findLeaf(Node root)
			{
				string path = "";
				var current = root;
				while (true)
				{
					if (current.LeftNode == null)
					{
						if (current.RightNode == null)
						{
							break;
						}
					}

					if (current.LeftNode != null)
					{
						current = current.LeftNode;
						path += 1;
					}
					else if (current.RightNode != null)
					{
						current = current.RightNode;
						path += 0;
					}
				}

				var ans = new Tuple<string, string>(path, current.Data);
				if (path == "") return ans;
				current.setNull();
				return ans;
			}

			string decoder()
			{
				List<string> lines2 = new FileReader().ReadLines("ans");
				var dictDecod = new Dictionary<string, string>();
				var words = new List<string>();
				for (int i = 1; i <= Convert.ToInt32(lines2[0]); i++)
				{
					var curr = lines2[i].Split();
					dictDecod.Add(curr[0], curr[1]);
				}

				for (int i = Convert.ToInt32(lines2[0]) + 1; i < lines2.Count; i++)
				{
					var wordDeCrypt = Convert.ToString(Convert.ToInt32(lines2[i], 10), 2);
					words.Add(wordDeCrypt);
				}

				var ListOfTokenz = new List<string>();
				foreach (var word in words)
				{
					var currentList = Tokenized(word);
					foreach (var token in currentList)
					{
						ListOfTokenz.Add(token);
					}
				}

				var stack = new Stack<string>();
				for (int i = ListOfTokenz.Count - 1; i >= 0; i--)
				{
					stack.Push(ListOfTokenz[i]);
				}
				var resultStr = "";
				foreach (var VARIABLE in stack)
				{
					Console.WriteLine(VARIABLE);
				}
				while (stack.Count > 0)
				{
					var newElement = stack.Pop();
					if (dictDecod.ContainsKey(newElement))
					{
						resultStr += dictDecod[newElement];
					}
					else
					{
						//110000100110
						var addIt = stack.Pop();
						stack.Push(newElement + addIt);
					}
						
				}
				Console.WriteLine(resultStr);
				return resultStr;
			}

			List<string> Tokenized(string expression)
			{
				string[] numbersList = {"1", "0"};

				var answearShit = new List<string>();

				for (var index = 0; index != expression.Length; index++)
				{
					var element = expression[index].ToString();

					if (numbersList.Contains(element))
					{
						answearShit.Add(element);
					}
				}

				return answearShit;


			}
		}
	}
}