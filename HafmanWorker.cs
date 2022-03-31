using Hafman;

namespace Havman;

public class HafmanWorker
{
	private Dictionary<string, string> codeDict { get; }
	private Dictionary<string, string> deCodeDict { get; }
	private List<string> lines { get; }

	public HafmanWorker(Node root, List<string> line)
	{
		lines = line;
		codeDict = new Dictionary<string, string>();
		deCodeDict = new Dictionary<string, string>();
		var path = "";
		while (path != " ")
		{
			var newLeaf = findLeaf(root);
			if (newLeaf.Item2.Length <= 1)
			{
				codeDict.Add(newLeaf.Item2, newLeaf.Item1);
				deCodeDict.Add(newLeaf.Item1, newLeaf.Item2);
			}

			if (newLeaf.Item1 == "")
			{
				path = " ";
			}
		}
	}

	public Tuple<string, string> findLeaf(Node root)
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
				path += 0;
			}
			else if (current.RightNode != null)
			{
				current = current.RightNode;
				path += 1;
			}
		}

		var ans = new Tuple<string, string>(path, current.Data);
		if (path == "") return ans;
		current.setNull();
		return ans;
	}

	public void WorkerIncode()
	{
		var newCrypt = "";
		var pathd = @"ans";
		newCrypt += deCodeDict.Count + Environment.NewLine;
		newCrypt = deCodeDict.Aggregate(newCrypt,
			(current, VARIABLE) => current + (VARIABLE.Key + " " + VARIABLE.Value + Environment.NewLine));
		var liner = lines.Aggregate("", (current, line) => current + line);
		var tokens = new Tokenizer().Tokenize(liner);
		var wordCrypt = "";
		foreach (var token in tokens)
		{
			wordCrypt += codeDict[token];
		}

		wordCrypt = Convert.ToString(Convert.ToInt64(wordCrypt, 2), 10);
		wordCrypt += Environment.NewLine;
		newCrypt += wordCrypt;
		File.WriteAllText(pathd, newCrypt);
	}

	public void WorkerDecode()
	{
		List<string> lines2 = new FileReader().ReadLines("ans");
		var dictDecod = new Dictionary<string, string>();
		var words = new List<string>();
		for (int i = 1; i <= Convert.ToInt32(lines2[0]); i++)
		{
			var curr = lines2[i].Split();
			dictDecod.Add(curr[1], curr[0]);
		}

		for (int i = Convert.ToInt32(lines2[0]) + 1; i < lines2.Count; i++)
		{
			var wordDeCrypt = Convert.ToString(Convert.ToInt64(lines2[i], 10), 2);
			words.Add(wordDeCrypt);
		}

		var ListOfTokens = new List<string>();
		foreach (var word in words)
		{
			var currentList = new Tokenizer().Tokenize(word);
			foreach (var token in currentList)
			{
				ListOfTokens.Add(token);
			}
		}

		var stack = new Stack<string>();
		for (int i = ListOfTokens.Count - 1; i >= 0; i--)
		{
			stack.Push(ListOfTokens[i]);
		}

		var resultStr = "";
		while (stack.Count > 0)
		{
			var newElement = stack.Pop();
			if (deCodeDict.ContainsKey(newElement))
			{
				resultStr += deCodeDict[newElement];
			}
			else
			{
				var addIt = stack.Pop();
				stack.Push(newElement + addIt);
			}
		}

		Console.WriteLine(resultStr);
	}
}