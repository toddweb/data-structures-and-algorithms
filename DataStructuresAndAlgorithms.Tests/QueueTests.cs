using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DataStructuresAndAlgorithms.Tests
{
	[TestClass]
	public class QueueTests
	{
		[TestMethod]
		public void GivenNonEmptyQueue_WhenPeek_ThenShouldReturnItemAtFront()
		{
			const string TargetItem = "one";

			var sut = new Queue<string>(2);

			sut.Enqueue(TargetItem);

			Assert.AreEqual(TargetItem, sut.Peek());
		}

		[TestMethod]
		public void GivenEmptyQueue_WhenIsEmpty_ThenShouldReturnTrue()
		{
			var sut = new Queue<string>(2);

			Assert.IsTrue(sut.IsEmpty());
		}

		[TestMethod]
		public void GivenNonEmptyQueue_WhenIsEmpty_ThenShouldReturnFalse()
		{
			var sut = new Queue<string>(2);

			sut.Enqueue("one");

			Assert.IsFalse(sut.IsEmpty());
		}

		[TestMethod]
		public void GivenEmptyQueue_WhenIsFull_ThenShouldReturnFalse()
		{
			var sut = new Queue<string>(2);

			Assert.IsFalse(sut.IsFull());
		}

		[TestMethod]
		public void GivenNonEmptyNonFullQueue_WhenIsFull_ThenShouldReturnFalse()
		{
			var sut = new Queue<string>(2);

			sut.Enqueue("one");

			Assert.IsFalse(sut.IsFull());
		}

		[TestMethod]
		public void GivenFullQueue_WhenIsFull_ThenShouldReturnTrue()
		{
			var sut = new Queue<string>(2);

			sut.Enqueue("one");
			sut.Enqueue("two");

			Assert.IsTrue(sut.IsFull());
		}

		[TestMethod]
		public void GivenEmptyQueue_WhenCount_ThenShouldReturnZero()
		{
			var sut = new Queue<string>(2);

			Assert.AreEqual(0, sut.Count);
		}

		[TestMethod]
		public void GivenQueue_WhenEnqueue_ThenCountIsIncremented()
		{
			var sut = new Queue<string>(2);

			sut.Enqueue("one");

			Assert.AreEqual(1, sut.Count);
		}

		[TestMethod, ExpectedException(typeof(InvalidOperationException))]
		public void GivenQueue_WhenEnqueuePastFull_ThenOverflowException()
		{
			var sut = new Queue<string>(1);

			sut.Enqueue("one");
			sut.Enqueue("two");
		}

		[TestMethod]
		public void GivenQueue_WhenDequeue_ThenCountIsDecremented()
		{
			var sut = new Queue<string>(2);

			sut.Enqueue("one");
			sut.Enqueue("two");
			sut.Dequeue();

			Assert.AreEqual(1, sut.Count);
		}

		[TestMethod, ExpectedException(typeof(InvalidOperationException))]
		public void GivenQueue_WhenDequeuePastEmpty_ThenUnderflowException()
		{
			var sut = new Queue<string>(1);

			sut.Enqueue("one");
			sut.Dequeue();
			sut.Dequeue();
		}
	}
}
