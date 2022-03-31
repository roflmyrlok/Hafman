namespace Havman;

public class createCodedDictsFromHafmanTree
{
	public Dictionary<string, string> codeDict { get; }
	public Dictionary<string, string> deCodeDict { get; }

	public createCodedDictsFromHafmanTree(BinaryTreeFromQueueOfFrequencyCreation binaryTree, List<string> lines)
	{
		codeDict = new Dictionary<string, string>();
		deCodeDict = new Dictionary<string, string>();
		var path = "";
		while (path != " ")
		{
			var newLeaf = binaryTree.findLeaf();
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
}