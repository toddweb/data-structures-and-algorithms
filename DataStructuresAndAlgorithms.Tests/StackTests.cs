using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresAndAlgorithms.Tests
{
	// TODO: test drain, is* methods
	[TestClass]
	public class StackTests
	{
		[TestMethod]
		public void GivenEmptyStack_WhenPeek_ThenShouldReturnDefaultT()
		{
			var sut = new Stack<int>(1);

			Assert.AreEqual(default(int), sut.Peek());
		}

		[TestMethod]
		public void GivenNonEmptyStack_WhenPeek_ThenShouldReturnTopItem()
		{
			const int TargetItem = 5;

			var sut = new Stack<int>(2);

			sut.Push(1);
			sut.Push(TargetItem);

			Assert.AreEqual(TargetItem, sut.Peek());
		}

		[TestMethod]
		public void GivenNonEmptyStack_WhenPop_ThenShouldReturnTopItem()
		{
			const int TargetItem = 5;

			var sut = new Stack<int>(2);

			sut.Push(3);
			sut.Push(TargetItem);

			Assert.AreEqual(TargetItem, sut.Pop());
		}
	}
}
