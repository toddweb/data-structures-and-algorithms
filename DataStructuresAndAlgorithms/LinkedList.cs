using System;
using System.Collections.Generic;

namespace DataStructuresAndAlgorithms
{
	public class LinkedList<T>
	{
		public LinkedList()
		{
			Head = new LinkedListNode<T>(default(T));
		}

		public LinkedListNode<T> Head { get; private set; }

		public LinkedListNode<T> DetectCycle()
		{
			var processedNodes = new LinkedListNode<T>[100];
			var next = Head.Next;
			var index = 0;

			while (next != null)
			{
				for (int i = 0; i < processedNodes.Length; i++)
					if (processedNodes[i] == next) return processedNodes[i];

				processedNodes[index] = next;
				index++;
				next = next.Next;
			}

			return null;
		}

		public LinkedListNode<T> ReverseAndCreateNew()
		{
			var next = Head.Next;
			var reversal = new List<LinkedListNode<T>>();

			while (next != null)
			{
				reversal.Add(next);
				next = next.Next;
			}

			for (int i = reversal.Count - 1; i >= 0; i--)
			{
				reversal[i].Next = i == 0 ? null : reversal[i - 1];
			}

			return reversal[reversal.Count - 1];
		}

		/*public LinkedList Reverse()
		{
			var reversal = new List<Node>();
			var currentNode = Head.Next;

			while (currentNode.Next != null)
			{
				reversal.Add(currentNode.Next);
				currentNode = currentNode.Next;
			}

			for (int i = reversal.Count - 1; i > 0; i--)
			{
				reversal[i].Next = reversal[i - 1];
			}

			Head = reversal[reversal.Count - 1];// ensure Head poitns to empty node
			reversal[0].Next = null;

			return this;
		}*/
	}
}
