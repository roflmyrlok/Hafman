namespace Havman;

public class BinaryTreeCreator
{
	public Node CreateTree (Dictionary<char,int> dictOfFrequency)
	{
		var queue = FormQueue(dictOfFrequency);
		while (!queue.Count.Equals(1))
		{
			var curr1 = queue.Dequeue();
			var curr2 = queue.Dequeue();
			var newNode = new Node
			{
				Data = curr1.Data + curr2.Data,
				LeftNode = curr1,
				RightNode = curr2
			};
			curr1.ParentNode = newNode;
			curr2.ParentNode = newNode;
			newNode.frequency = curr1.frequency + curr2.frequency;
			queue.Enqueue(newNode, newNode.frequency);
		}

		var root = queue.Dequeue();
		return root;
	}
	
	
	private PriorityQueue<Node,int> FormQueue(Dictionary<char, int> dictOfFrequency)
	{
		var newQueue = new PriorityQueue<Node, int>();
		foreach (var keyValue in dictOfFrequency)
		{
			var curr = new Node();
			curr.Data = keyValue.Key.ToString();
			curr.frequency = keyValue.Value;
			newQueue.Enqueue(curr,keyValue.Value);
		}
		return newQueue;
	}
}