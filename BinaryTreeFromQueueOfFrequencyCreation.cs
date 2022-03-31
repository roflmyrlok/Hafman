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
				Data = curr1.Data + curr2.Data,
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
	public Tuple<string, string> findLeaf()
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