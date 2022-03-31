using Havman;

namespace Hafman;

class Program
{
	static void Main(string[] args)
	{
		var pathToNonCodedTxt = "lines.txt";
		var textReader = new FileReader();
		var lines = textReader.ReadLines(pathToNonCodedTxt);
		var newFrequencyAnalyzer = new FrequencyAnalyzer();
		var dictOfFrequency = newFrequencyAnalyzer.AnalyzeFrequency(lines);
		var treeCreator = new BinaryTreeCreator();
		var binaryTree = treeCreator.CreateTree(dictOfFrequency);
		var dictsFromHafmanTree = new createCodedDictsFromHafmanTree(binaryTree, lines);
		new createNewFileWithCodes(dictsFromHafmanTree.codeDict, dictsFromHafmanTree.deCodeDict, lines);
		new decoderOfHafmanNote().decode();
	}
}