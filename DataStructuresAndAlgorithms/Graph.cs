using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAndAlgorithms
{
	class Graph
	{
		// http://www.tutorialspoint.com/data_structures_algorithms/graph_data_structure.htm
		// http://www.tutorialspoint.com/data_structures_algorithms/tree_data_structure.htm
	}

	/*public class DepthFirstSearch<T>
	{
		private Stack<T> stack;

		public Stack<T> Execute(BinaryTree<T> node)
		{
			ExecuteInternal(node);
			return stack;
		}

		private void ExecuteInternal(BinaryTree<T> node)
		{
			stack.Push(node.Key);

			if (node.Left != null && !node.Left.HasBeenVisisted)
			{
				node.Left.Visit();
				ExecuteInternal(node.Left);
			}

			if (node.Right != null && !node.Right.HasBeenVisisted)
			{
				node.Right.Visit();
				ExecuteInternal(node.Right);
			}
		}
	}*/
}
