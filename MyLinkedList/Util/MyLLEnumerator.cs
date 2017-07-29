using System;
using System.Collections;
using System.Collections.Generic;

namespace MyLinkedList.Model
{
	class MyLLEnumerator<T> : IEnumerator<T>
	{

		private MyLinkedList<T> myLL;
		private Node<T> currentNode; 
		private int index = 0;

		public T Current
		{
			get
			{
				try
				{
					return currentNode.Data;
				}
				catch (ArgumentNullException)
				{
					throw new ArgumentNullException("MyLinkedList<T> is empty");
				}
			}
		}
		public MyLLEnumerator(MyLinkedList<T> myLL)
		{
			this.myLL = myLL;
			currentNode = null; 
		}

		object IEnumerator.Current
		{
			get
			{
				return Current;
			}
		}

		

		public void Dispose()
		{
		}

		public bool MoveNext()
		{
			if (index < myLL.Count)
			{
				//Console.WriteLine("index = " + index);
				index++;
				if (currentNode == null) currentNode = myLL.Head;
				else
					currentNode = currentNode.Next;
				return true;
			}
			return false;
		}

		public void Reset()
		{
			currentNode = myLL.Head;
		}
	}
}