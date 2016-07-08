using System;

namespace DataStructuresAndAlgorithms
{
	public class Stack<T>
	{
		const int EmptyIndex = -1;

		private T[] stack;
		private int top;

		public Stack(int size)
		{
			if (size <= 0) throw new ArgumentException("Must have value", "size");

			stack = new T[size];
			top = EmptyIndex;
		}

		public bool IsEmpty()
		{
			return top == EmptyIndex;
		}

		public bool IsFull()
		{
			return top == stack.Length - 1;
		}

		public T Peek()
		{
			return !IsEmpty() ? stack[top] : default(T);
		}

		public T Pop()
		{
			if (IsEmpty()) throw new InvalidOperationException("Underflow");

			T item = stack[top];
			stack[top] = default(T);
			top -= 1;

			return item;
		}

		public void Push(T item)
		{
			if (IsFull()) throw new InvalidOperationException("Overflow");

			top += 1;
			stack[top] = item;
		}
    }
}
