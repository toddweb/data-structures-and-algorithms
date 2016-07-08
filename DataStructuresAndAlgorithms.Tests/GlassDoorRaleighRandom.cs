using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DataStructuresAndAlgorithms.Tests
{
	[TestClass]
	public class GlassDoorRaleighRandom
	{
		[TestMethod]
		public void GivenAnArraryAndATarget_SeeIfAnyTwoNumbersAddUpToTarget()
		{
			const int Target = 14;

			var arr = new int[10] { 7, 2, 3, 4, 9, 6, 5, 7, 8, 6 };

			for (int i = 0; i < arr.Length; i++)
			{
				for (int j = 0; j < arr.Length; j++)
				{
					if (i == j) continue;

					if (arr[i] + arr[j] == Target)
					{
						Assert.IsTrue(true);
						Console.WriteLine(string.Format("{0} + {1} == {2}", arr[i], arr[j], Target));
						return;
					}
				}
			}

			Assert.Fail();
		}

		[TestMethod]
		public void GivenAString_ParseToAnInteger()
		{
			const string Target = "1234598877";
			const int TargetInt = 1234598877;

			var solution = 0;

			for (int i = 0; i < Target.Length; i++)
			{
				var next = (Target[i] - 48) * (int)Math.Pow(10, (Target.Length - i - 1));

				Console.WriteLine(next);
				solution += next;
			}

			Assert.AreEqual(TargetInt, solution);
		}

		[TestMethod]
		public void GivenTwoStrings_ProveOneContainsTheOther()
		{
			var string1 = "test";
			var string2 = "start" + string1 + "end";

			for (int i = 0; i < string1.Length; i++)
			{
				var letterIsFound = false;

				for (int j = 0; j < string2.Length; j++)
				{
					if (string1[i] == string2[j])
					{
						letterIsFound = true;
						break;
					}
				}

				if (!letterIsFound) Assert.Fail();
			}
		}

		[TestMethod]
		public void GivenAString_ReverseIt()
		{
			const string Target = "target";

			var reversedTarget = string.Empty;
			var stack = new Stack<char>(Target.Length);

			for (int i = 0; i < Target.Length; i++)
			{
				stack.Push(Target[i]);
			}

			while (!stack.IsEmpty())
				reversedTarget += stack.Pop();

			Assert.AreEqual("tegrat", reversedTarget);
		}

		[TestMethod]
		public void GivenUnsortedArray_BubbleSortIt()
		{
			const string ExpectedSort = "1568102429333435";

			var unsorted = new int[10] { 10, 1, 5, 8, 35, 24, 33, 34, 29, 6 };

			for (int i = 0; i < unsorted.Length - 1; i++)
			{
				for (int j = 0; j < unsorted.Length - i - 1; j++)
				{
					if (unsorted[j] > unsorted[j + 1])
					{
						var temp = unsorted[j];
						unsorted[j] = unsorted[j + 1];
						unsorted[j + 1] = temp;
					}
				}
			}

			Assert.AreEqual(ExpectedSort, string.Join(string.Empty, unsorted));
		}

		[TestMethod]
		public void GivenUnsortedArray_SelectionSortIt()
		{
			const string ExpectedSort = "1568102429333435";

			var unsorted = new int[10] { 10, 1, 5, 8, 35, 24, 33, 34, 29, 6 };
			var minIndex = 0;

			for (int i = 0; i < unsorted.Length - 1; i++)
			{
				minIndex = i;

				for (int j = i + 1; j < unsorted.Length; j++)
					if (unsorted[j] < unsorted[minIndex]) minIndex = j;

				var temp = unsorted[minIndex];
				unsorted[minIndex] = unsorted[i];
				unsorted[i] = temp;
			}

			Assert.AreEqual(ExpectedSort, string.Join(string.Empty, unsorted));
		}
	}
}
