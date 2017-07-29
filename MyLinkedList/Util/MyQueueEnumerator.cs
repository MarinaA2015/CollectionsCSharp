using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinkedList.Model
{
	class MyQueueEnumerator<T> : IEnumerator<T>
	{
		private T[] arrayQueue;
		private int head;
		private int tail;
		private int currentNum = -1;

		public MyQueueEnumerator(T[] arrayQueue, int head, int tail)
		{
			this.arrayQueue = arrayQueue;
			this.head = head;
			this.tail = tail;
			
		}
		public T Current
		{
			get
			{
				return arrayQueue[currentNum];
			}
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
			if (head == -1) return false;
			if (currentNum == tail) return false;
			if (currentNum == -1) currentNum = head;
			else currentNum = (currentNum < arrayQueue.Length - 1) ? currentNum + 1 : 0;
			return true;

		}

		public void Reset()
		{
			currentNum = -1;
		}
	}
}
