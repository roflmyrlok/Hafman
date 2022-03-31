namespace Havman;

public class createCodedDictsFromHafmanTree
{
	public Dictionary<string, string> codeDict { get; }
	public Dictionary<string, string> deCodeDict { get; }

	public createCodedDictsFromHafmanTree(Node root, List<string> lines)
	{
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
}