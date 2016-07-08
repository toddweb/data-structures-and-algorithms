using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresAndAlgorithms.Tests
{
	[TestClass]
	public class LinkedListTests
	{
		[TestMethod]
		public void GivenALinkedList_ReverseTheElements()
		{
			var sut = new LinkedList<int>();

			sut.Head.Next = new LinkedListNode<int>(0,
				 new LinkedListNode<int>(1,
					new LinkedListNode<int>(2,
					new LinkedListNode<int>(3,
					new LinkedListNode<int>(4, null)))));

			Console.WriteLine(sut.ReverseAndCreateNew().ToString());
		}

		[TestMethod]
		public void GivenALinkedListWithCycle_DetectCycleNode()
		{
			var sut = new LinkedList<int>();

			sut.Head.Next = new LinkedListNode<int>(0,
				 new LinkedListNode<int>(1,
					new LinkedListNode<int>(2,
					new LinkedListNode<int>(3,
					new LinkedListNode<int>(4, null)))));

			var cycleNode = sut.Head.Next;

			sut.Head.Next.Next.Next.Next.Next = cycleNode;

			Assert.AreEqual(cycleNode, sut.DetectCycle());

			sut.Head.Next.Next.Next.Next.Next = null;

			Assert.IsNull(sut.DetectCycle());
		}
	}
}
