using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms.Tests
{
	[TestClass]
	public class HashTableTests
	{
		[TestMethod]
		public void GivenHashTable_WhenAdd_ThenShouldIncreaseCount()
		{
			var sut = new HashTable<string, string>();
			
			sut.Add("key", "value");

			Assert.AreEqual(1, sut.Count);
		}

		[TestMethod]
		public void GivenHashTable_WhenDelete_ThenShouldDecreaseCount()
		{
			const string TargetKey = "key";

			var sut = new HashTable<string, string>();

			sut.Add(TargetKey, "value");
			sut.Add("key1", "value");
			sut.Delete(TargetKey);

			Assert.AreEqual(1, sut.Count);
		}

		[TestMethod]
		public void GivenHashTable_WhenAddSameItemTwice_ThenShouldIncreaseCount()
		{
			const string Value = "value";

			var sut = new HashTable<string, string>();

			sut.Add("key", "value");
			sut.Add("key", "value");

			Assert.AreEqual(2, sut.Count);
		}

		[TestMethod]
		public void GivenHashTable_WhenIndexer_ThenShouldReturnCorrectValue()
		{
			const string TargetKey = "key1";
			const string TargetValue = "value1";

			var sut = new HashTable<string, string>();

			sut.Add(TargetKey, TargetValue);
			sut.Add("key2", "value2");

			Assert.AreEqual(TargetValue, sut[TargetKey]);
		}
	}
}
