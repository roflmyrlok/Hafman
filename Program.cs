using Havman;

namespace Hafman;

class Program
{
	static void Main(string[] args)
	{
		var pathToNonCodedTxt = "lines.txt";
		List<string> lines = new FileReader().ReadLines(pathToNonCodedTxt);
		var DictOfFrequency = new TxtLinesToFrequencyDict(lines);
		var queue = new SplitDictToQueue(DictOfFrequency.CharFrequencyDictionary).PriorityQueue;
		var binaryTree = new BinaryTreeFromQueueOfFrequencyCreation(queue);
		var dictsFromHafmanTree = new createCodedDictsFromHafmanTree(binaryTree, lines);
		new createNewFileWithCodes(dictsFromHafmanTree.codeDict, dictsFromHafmanTree.deCodeDict, lines);
		new decoderOfHafmanNote().decode();

	}
}