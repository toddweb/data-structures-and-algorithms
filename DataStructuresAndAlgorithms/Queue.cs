using System;

namespace DataStructuresAndAlgorithms
{
	public class Queue<T> where T : class
	{
		private T[] queue;
		private int front;
		private int count;

		public Queue(int size)
		{
			if (size <= 0) throw new ArgumentException("Must have value", "size");
			queue = new T[size];
		}

		public int Count { get { return count; } }

		public int Size { get { return queue.Length; } }

		public Queue<T> Copy()
		{
			var newQueue = new Queue<T>(count);

			for (int i = 0; i < count; i++)
				newQueue.Enqueue(queue[i]);

			return newQueue;
		}

		public T Dequeue()
		{
			if (IsEmpty()) throw new InvalidOperationException("Underflow");

			T item = queue[front];
			queue[front] = default(T);
			AdvanceFront();
			count--;

			return item;
		}
		
		public void Enqueue(T item)
		{
			if (IsFull()) throw new InvalidOperationException("Overflow");

			queue[GetNextAvailableIndex()] = item;
			count++;
		}

		public T Intersect(Queue<T> path)
		{
			T intesection = null;
			var queue1 = ToArray();
			var queue2 = path.ToArray();
			var found = false;
			
			for (int i = queue1.Length - 1; i >= 0; i--)
			{
				if (queue1[i] == default(T)) continue;
				if (found) break;

				for (int j = queue2.Length - 1; j >= 0; j--)
				{
					if (queue2[j] == default(T)) continue;
					if (queue2[j] == queue1[i])
					{
						found = true;
						intesection = queue1[i];
						break;
					}
				}
			}

			return intesection;
		}

		public bool IsEmpty()
		{
			return count == 0;
		}

		public bool IsFull()
		{
			return count == queue.Length;
		}

		public T Peek()
		{
			return queue[front];
		}

		public T[] ToArray()
		{
			var copy = new T[Size];

			queue.CopyTo(copy, 0);

			return copy;
		}

		// Accounts for wrap-around array
		private void AdvanceFront()
		{
			front = front == queue.Length - 1 ? 0 : front + 1;
		}

		// Probably could create a formula to do this quicker than blind looping and wrapping back around
		private int GetNextAvailableIndex()
		{
			if (count == 0) return 0;

			for (int i = front; i < queue.Length; i++)
				if (queue[i] == default(T)) return i;

			for (int i = 0; i < front; i++)
				if (queue[i] == default(T)) return i;

			return 0;
		}
	}
}
