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
			List<string> lines = new FileReader().ReadLines("lines.txt");
			SplitLines charsDict = new SplitLines();
			charsDict.splitNFill(lines);
			var queue = new SplitCharsToQueue(charsDict.Charnumber);
			while (!queue.PriorityQueue.Count.Equals(1))
			{
				var curr1 = queue.PriorityQueue.Dequeue();
				var curr2 = queue.PriorityQueue.Dequeue();
				var newNode = new Node
				{
					Data = "",//data1 + data2 for full tree
					LeftNode = curr1,
					RightNode = curr2
				};
				curr1.ParentNode = newNode;
				curr2.ParentNode = newNode;
				newNode.frequency = curr1.frequency + curr2.frequency;
				queue.PriorityQueue.Enqueue(newNode, newNode.frequency);
			}

			var root = queue.PriorityQueue.Dequeue();
			root.ParentNode = new Node();
			var codeDict = new Dictionary<string, string>();
			var deCodeDict = new Dictionary<string, string>();
			for (int leafs = 0; leafs <= charsDict.Charnumber.Count; leafs++ )
			{
				var newLeaf = findLeaf(root);
				if (newLeaf.Item2 == "") continue;//rem for full data
				codeDict.Add(newLeaf.Item2, newLeaf.Item1);
				deCodeDict.Add(newLeaf.Item1,newLeaf.Item2);
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
			Tuple<string,string> findLeaf(Node root)
			{
				string path = "";
				var current = root;
				while (true){
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
				var dictDecod = new Dictionary<string,string>();
				var words = new List<string>();
				for (int i = 1; i < Convert.ToInt32(lines2[0]); i++)
				{
					var curr = lines2[i].Split();
					dictDecod.Add(curr[0],curr[1]);
				}

				for (int i = Convert.ToInt32(lines2[0]) + 1; i < lines2.Count; i++)
				{
					var wordDeCrypt = Convert.ToString(Convert.ToInt32(lines2[i], 10), 2);
					words.Add(wordDeCrypt);
				}

				var status = 0;
				while (true)
				{
					var item = false;
					while (item == false)
					{
						var i = 0;
						
					}
				}
				return "Ds";
			}
		}
	}
}