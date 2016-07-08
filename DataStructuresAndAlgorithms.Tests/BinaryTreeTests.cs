using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresAndAlgorithms.Tests
{
	[TestClass]
	public class BinaryTreeTests
	{
		[TestMethod]
		public void GivenTree_WhenDepthFirstSearch_ThenOutputShouldMatch()
		{
			const string ExpectedOutput = "ABDFCGHIJ";
			/*
			 						A
			 					  / |
			 					 B  C
							   / |  |
							  D  F	G
								  /   \
								H      I
								        \
										 J
			 */
			var sut = new BinaryTree<string>(
				new BinaryTreeNode<string>("A",
					new BinaryTreeNode<string>("B",
						new BinaryTreeNode<string>("D"),
						new BinaryTreeNode<string>("F")),
					new BinaryTreeNode<string>("C",
						new BinaryTreeNode<string>("G",
							new BinaryTreeNode<string>("H"),
							new BinaryTreeNode<string>("I",
								null,
								new BinaryTreeNode<string>("J"))))));

			/*var sut = new BinaryTree<string>(new BinaryTreeNode<string>("A"));
			sut.Root.Left = new BinaryTreeNode<string>("B");
			sut.Root.Left.Left = new BinaryTreeNode<string>("D");
			sut.Root.Left.Right = new BinaryTreeNode<string>("F");
			sut.Root.Right = new BinaryTreeNode<string>("C");
			sut.Root.Right.Left = new BinaryTreeNode<string>("G");
			sut.Root.Right.Left.Left = new BinaryTreeNode<string>("H");
			sut.Root.Right.Left.Right = new BinaryTreeNode<string>("I");
			sut.Root.Right.Left.Right.Right = new BinaryTreeNode<string>("J");*/

			Assert.AreEqual(ExpectedOutput, string.Join(string.Empty, BinaryTree<string>.DepthFirstSearch(sut.Root)));
		}
	}
}
