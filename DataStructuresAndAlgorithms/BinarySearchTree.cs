namespace DataStructuresAndAlgorithms
{
	public class BinarySearchTree
	{
		public BinaryTreeNode<int> Root { get; set; }

		public BinarySearchTree(BinaryTreeNode<int> root)
		{
			Root = root;
		}

		/*public void Insert(BinaryTreeNode<int> node, int key)
		{
			
		}*/

		public BinarySearchTreeSearchResult Search(BinaryTreeNode<int> node, int key)
		{
			var result = new BinarySearchTreeSearchResult();

			InternalSearch(node, key, result);

			return result;
		}

		private void InternalSearch(BinaryTreeNode<int> node, int key, BinarySearchTreeSearchResult result)
		{
			result.Path.Enqueue(node);
			result.NodesVisited++;

			if (node.Key == key)
			{
				result.Node = node;
				return;
			}

			if (node.Left != null && key < node.Key)
				InternalSearch(node.Left, key, result);

			if (node.Right != null && key > node.Key)
				InternalSearch(node.Right, key, result);
		}

		public BinaryTreeNode<int> FindCommonAncestor(BinaryTreeNode<int> node1, BinaryTreeNode<int> node2)
		{
			var node1SearchResult = Search(Root, node1.Key);
			var node2SearchResult = Search(Root, node2.Key);

			return node1SearchResult.IsFound() && node2SearchResult.IsFound()
				? node1SearchResult.Path.Intersect(node2SearchResult.Path)
				: null;
		}
	}
}
