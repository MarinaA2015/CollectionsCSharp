using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinkedList.Model
{

	class _MyQueue<T> : IEnumerable<T>
	{
		public const int DEFAULT_CAPACITY = 10;
		public int Capacity = DEFAULT_CAPACITY;
		public int Count { private set; get; }
		private T[] arrayQueue;
		private int head = -1;
		private int tail = 0;

		public _MyQueue()
		{
			this.Count = 0;
			this.Capacity = DEFAULT_CAPACITY;
			arrayQueue = new T[Capacity];
		}

		public _MyQueue(IEnumerable<T> coll)
		{
			this.Count = 0;
			arrayQueue = new T[Capacity];
			foreach (T data in coll)
			{
				Enqueue(data);
			}
			TrimExcees();
		}

		public _MyQueue(int capacity)
		{
			if (capacity < 0) throw new ArgumentOutOfRangeException("Capacity is less than zero");
			this.Count = 0;
			this.Capacity = capacity;
			arrayQueue = new T[capacity];
		}

		public void Clear()
		{
			arrayQueue = new T[DEFAULT_CAPACITY];
			this.Count = 0;
			this.head = -1;
			this.tail = 0;
		}

		public bool Contains(T data)
		{
			if (head == -1) return false;
			int current = head;
			T currentEl = arrayQueue[current];
			for(int i=1; i <= Count; i++)
			{
				if (currentEl.Equals(data)) return true;
				current = this.NextNumberInLoop(current);
				currentEl = arrayQueue[current];
			}
			return false;
		}

		public void CopyTo(T[] arrayT, int index)
		{
			if (head == -1) return;
			if (arrayT == null) throw new ArgumentNullException("array is null");
			if (index < 0) throw new ArgumentOutOfRangeException("arrayIndex is less than zero");
			if (arrayT.Length < Count + index) throw new ArgumentException("The number of elements in the source Queue<T>" +
							" is greater than the available space from arrayIndex to the end of the destination array.");
			int current = head;
			T currentEl = arrayQueue[current];
			for (int i = 0; i < Count; i++)
			{
				arrayT[i + index] = arrayQueue[current];
				current = this.NextNumberInLoop(current);

				currentEl = arrayQueue[current];
			}

		}

		public T Dequeue()
		{
			T res;
			if (head == -1) throw new InvalidOperationException("The Queue<T> is empty");
			res = arrayQueue[head];
			if (Count == 1)
			{
				head = -1;
				tail = 0;
			}
			else
			{
				head = NextNumberInLoop(head); 
			}
			Count--;
			return res;
		}

		public void Enqueue(T data)
		{
			if (Count == Capacity) IncreaseCapacity();
			if (head == -1) head = 0;
			else tail = NextNumberInLoop(tail);
			Count++;
			arrayQueue[tail] = data;
		}

		public T Peek()
		{
			if (head == -1) throw new InvalidOperationException("The Queue<T> is empty");
			return arrayQueue[head];
		}

		public T[] ToArray()
		{
			T[] res = new T[Count];
			this.CopyTo(res, 0);
			return res;
		}
		
		public override string ToString()
		{
			string res = "";
			int current = head;
			T currentEl = arrayQueue[current];
			for (int i = 0; i < Count; i++)
			{
				res = res + arrayQueue[current] + " ";
				current = this.NextNumberInLoop(current);
				currentEl = arrayQueue[current];
			}
			return res;
		}
		
		public void TrimExcees()
		{
			if (Count > Capacity * 0.9) return;
			Capacity = Count;
			T[] arrayAdd = new T[Capacity];
			CopyTo(arrayAdd, 0);
			arrayQueue = arrayAdd;
		}

		private int NextNumberInLoop(int num)
		{
			return (num < Capacity - 1) ? num + 1 : 0;
		}

		private void IncreaseCapacity() {
			
			T[] arrayAdd = new T[Capacity*2];
			this.CopyTo(arrayAdd, 0);
			Capacity = Capacity * 2;
			arrayQueue = arrayAdd;
		}

		public IEnumerator<T> GetEnumerator()
		{
			int currentNum = -1;
			if (head == -1) yield break;
			do
			{
				if (currentNum == -1) currentNum = head;
				else currentNum = NextNumberInLoop(currentNum);
				yield return arrayQueue[currentNum];

			} while (currentNum != tail);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
