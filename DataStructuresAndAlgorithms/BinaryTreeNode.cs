namespace DataStructuresAndAlgorithms
{
	public class BinaryTreeNode<T>
	{
		public T Key { get; private set; }
		public BinaryTreeNode<T> Left { get; set; }
		public BinaryTreeNode<T> Right { get; set; }
		public bool HasBeenVisisted { get; private set; }

		public BinaryTreeNode(T key, BinaryTreeNode<T> left = null, BinaryTreeNode<T> right = null)
		{
			Key = key;
			Left = left;
			Right = right;
		}

		public void UnVisit()
		{
			HasBeenVisisted = false;
		}

		public void Visit()
		{
			HasBeenVisisted = true;
		}
	}
}
