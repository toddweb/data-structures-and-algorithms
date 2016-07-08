using DataStructuresAndAlgorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DataStructuresAndAlgorithms.Tests
{
	[TestClass]
	public class BinarySearchTreeTests
	{
		private BinarySearchTree sut;

		[TestInitialize]
		public void TestInitialize()
		{
			/*
					                  20
					                /    \
					              15      25
					             /  \    /  \
					           10   16 21   30
			 */
			sut = new BinarySearchTree(new BinaryTreeNode<int>(20));

			sut.Root.Left = new BinaryTreeNode<int>(15);
			sut.Root.Left.Left = new BinaryTreeNode<int>(10);
			sut.Root.Left.Right = new BinaryTreeNode<int>(16);
			sut.Root.Right = new BinaryTreeNode<int>(25);
			sut.Root.Right.Left = new BinaryTreeNode<int>(21);
			sut.Root.Right.Right = new BinaryTreeNode<int>(30);
		}

		[TestMethod]
		public void GivenTree_WhenSearch_ThenShouldFindWithCorrectSteps()
		{
			var result = sut.Search(sut.Root, 30);

			Assert.AreEqual(sut.Root.Right.Right, result.Node);
			Assert.AreEqual(3, result.NodesVisited);
			while (!result.Path.IsEmpty())
				Console.WriteLine(result.Path.Dequeue().Key);

			result = sut.Search(sut.Root, 21);
			Assert.AreEqual(sut.Root.Right.Left, result.Node);
			Assert.AreEqual(3, result.NodesVisited);

			result = sut.Search(sut.Root, 10);
			Assert.AreEqual(sut.Root.Left.Left, result.Node);
			Assert.AreEqual(3, result.NodesVisited);

			result = sut.Search(sut.Root, 20);
			Assert.AreEqual(sut.Root, result.Node);
			Assert.AreEqual(1, result.NodesVisited);

			result = sut.Search(sut.Root.Left, 16);
			Assert.AreEqual(sut.Root.Left.Right, result.Node);
			Assert.AreEqual(2, result.NodesVisited);

			result = sut.Search(sut.Root.Left.Right, 16);
			Assert.AreEqual(sut.Root.Left.Right, result.Node);
			Assert.AreEqual(1, result.NodesVisited);
		}

		[TestMethod]
		public void GivenTree_WhenCommonAncestor_ThenShouldReturnCorrectAncestor()
		{
			var expectedCommonAncestor = sut.Search(sut.Root, 15).Node;
			var node1 = sut.Search(sut.Root, 10).Node;
			var node2 = sut.Search(sut.Root, 16).Node;

			Assert.AreEqual(expectedCommonAncestor.Key, sut.FindCommonAncestor(node1, node2).Key);

			expectedCommonAncestor = sut.Search(sut.Root, 20).Node;
			node1 = sut.Search(sut.Root, 10).Node;
			node2 = sut.Search(sut.Root, 30).Node;
			Assert.AreEqual(expectedCommonAncestor.Key, sut.FindCommonAncestor(node1, node2).Key);
		}
	}
}
