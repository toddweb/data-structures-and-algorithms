namespace DataStructuresAndAlgorithms
{
	public class BinaryTree<T>
	{
		public BinaryTreeNode<T> Root { get; set; }

		public BinaryTree(BinaryTreeNode<T> root)
		{
			Root = root;
		}
		
		public static string DepthFirstSearch(BinaryTreeNode<T> node)
		{
			var output = node.Key.ToString();

			if (node.Left != null && !node.Left.HasBeenVisisted)
			{
				node.Left.Visit();
				output += DepthFirstSearch(node.Left);
			}

			if (node.Right != null && !node.Right.HasBeenVisisted)
			{
				node.Right.Visit();
				output += DepthFirstSearch(node.Right);
			}

			return output;
		}
	}
}
