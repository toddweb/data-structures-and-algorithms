namespace DataStructuresAndAlgorithms
{
	public class BinarySearchTreeSearchResult
	{
		public BinarySearchTreeSearchResult()
		{
			Path = new Queue<BinaryTreeNode<int>>(100);
		}

		public int NodesVisited { get; set; }
		public BinaryTreeNode<int> Node { get; set; }
		public Queue<BinaryTreeNode<int>> Path { get; set; }

		public bool IsFound()
		{
			return Node != null;
		}
	}
}
