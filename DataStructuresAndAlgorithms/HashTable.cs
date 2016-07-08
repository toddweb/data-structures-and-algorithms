using System;

namespace DataStructuresAndAlgorithms
{
	/// <summary>
	/// 1. convert keys into array indices
	/// 2. store item in buckets?
	/// 2a. separate chaining with linkedlist
	/// </summary>
	public class HashTable<TKey, TValue> where TKey : class where TValue : class
	{
		private const int DefaultCapacity = 100;

		private HashTableBucket<TKey, TValue>[] buckets;
		private int count;

		public HashTable()
		{
			buckets = new HashTableBucket<TKey, TValue>[DefaultCapacity];
		}

		public int Count { get { return count; } }

		public TValue this[TKey key]
		{
			get
			{
				var bucket = buckets[GetHash(key)];

				if (bucket != null)
				{
					if (bucket.Next == null && bucket.Key == key) return bucket.Value;

					var currentBucketNode = bucket;

					while (currentBucketNode.Next != null)
					{
						if (currentBucketNode.Next == null && currentBucketNode.Key == key) return currentBucketNode.Value;
						currentBucketNode = currentBucketNode.Next;
					}
				}

				return null;
			}
		}

		public void Add(TKey key, TValue value)
		{
			var hash = GetHash(key);

			if (buckets[hash] == null)
				buckets[hash] = new HashTableBucket<TKey, TValue>(hash, key, value);
			else
			{
				// TODO: avoid dup keys even if hashes are equal
				var currentBucketNode = buckets[hash];

				while (currentBucketNode.Next != null)
					currentBucketNode = currentBucketNode.Next;

				currentBucketNode.Next = new HashTableBucket<TKey, TValue>(hash, key, value);
			}

			count++;
		}

		public void Delete(TKey key)
		{
			// TODO: honor Separate Chaining
			buckets[GetHash(key)] = null;
			count--;
		}

		public TValue Search(TKey key)
		{
			// TODO: honor Separate Chaining
			var bucket = buckets[GetHash(key)];

			return bucket == null ? null : bucket.Value;
		}

		private uint GetHash(TKey key)
		{
			return (uint)(Math.Abs(key.GetHashCode()) % buckets.Length);
		}
	}

	internal class HashTableBucket<TKey, TValue>
	{
		public HashTableBucket(uint hash, TKey key, TValue value)
		{
			Hash = hash;
			Key = key;
			Value = value;
		}

		public uint Hash { get; set; }
		public TKey Key { get; set; }
		public TValue Value { get; set; }
		public HashTableBucket<TKey, TValue> Next { get; set; }
	}
}
