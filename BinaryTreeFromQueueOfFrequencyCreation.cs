namespace Havman;

public class BinaryTreeFromQueueOfFrequencyCreation
{
	public Node root { get; set; }
	public BinaryTreeFromQueueOfFrequencyCreation(PriorityQueue<Node, int> queue)
	{
		while (!queue.Count.Equals(1))
		{
			var curr1 = queue.Dequeue();
			var curr2 = queue.Dequeue();
			var newNode = new Node
			{
				Data = "", //data1 + data2 for full tree
				LeftNode = curr1,
				RightNode = curr2
			};
			curr1.ParentNode = newNode;
			curr2.ParentNode = newNode;
			newNode.frequency = curr1.frequency + curr2.frequency;
			queue.Enqueue(newNode, newNode.frequency);
		}

		root = queue.Dequeue();
	}
}