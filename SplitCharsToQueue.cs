using System.Collections.Generic;
using System.Linq;

namespace Havman
{
	public class SplitCharsToQueue
	{
		public PriorityQueue<Node, int> PriorityQueue;

		public SplitCharsToQueue(Dictionary<char, int> dictOfFrequency)
		{
			PriorityQueue = new PriorityQueue<Node, int>();
			foreach (var keyValue in dictOfFrequency)
			{
				var curr = new Node();
				curr.Data = keyValue.Key.ToString();
				curr.frequency = keyValue.Value;
				PriorityQueue.Enqueue(curr,keyValue.Value);
			}
		}
	}
}