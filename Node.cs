namespace Havman
{
	public class Node
	{
		public Node ParentNode { get; set; }
		public Node LeftNode { get; set; }
		public Node RightNode { get; set; }

		public int frequency { get; set; }
		public string Data { get; set; }

		public void setNull()
		{
			
			if (ParentNode.LeftNode == this)
			{
				ParentNode.LeftNode = null;
			}
			if (ParentNode.RightNode == this)
			{
				ParentNode.RightNode = null;
			}

			ParentNode = null;
			LeftNode = null;
			RightNode = null;
		}
	}
}