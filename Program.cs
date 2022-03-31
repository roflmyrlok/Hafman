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
		var HafmanCoder = new HafmanWorker(binaryTree, lines);
		HafmanCoder.WorkerIncode();
		HafmanCoder.WorkerDecode();
	}
}