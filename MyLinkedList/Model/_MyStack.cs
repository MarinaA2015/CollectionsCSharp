using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MyLinkedList.Model
{
	class MyStack<T> : IEnumerable<T>
	{
		private int Capacity; 
		public int Count  { get; private set; }
		private T[] arrayStack;
		public const int DEFAULT_CAPACITY = 10;


		public MyStack()
		{
			this.Capacity = DEFAULT_CAPACITY;
			this.Count = 0;
			arrayStack = new T[Capacity];
			
		}
		public MyStack(IEnumerable<T> coll)
		{
			this.Capacity = DEFAULT_CAPACITY;
			this.Count = 0;
			arrayStack = new T[Capacity];			
			foreach (T data in coll)
				Push(data);
			TrimExcees();
		}
		public T Peek()
		{
			if (Count == 0) throw new InvalidOperationException("The Stack<T> is empty");
			return arrayStack[Count - 1];
		}

		public T Pop()
		{
			if (Count == 0) throw new InvalidOperationException("The Stack<T> is empty");
			T res = arrayStack[Count - 1];
			Count--;
			return res;
		}

		public void Push(T data)
		{
			if (Count == Capacity) IncreaseCapacity();
			arrayStack[Count] = data;
			Count++;
		}

		private void IncreaseCapacity()
		{
			Capacity = Capacity * 2;
			T[] arrayAdd = new T[Capacity];
			CopyTo(arrayAdd, 0);
			arrayStack = arrayAdd;
		}

		public T[] ToArray()
		{
			T[] arr = new T[Count];
			for (int i = Count - 1; i >= 0; i--)
				arr[Count - 1 - i] = arrayStack[i];
			return arr;
		}

		public override string ToString()
		{
			string res = "";
			for (int i = 0; i < Count; i++)
				res = res + arrayStack[i] + " ";
			return res;
		}

		public bool Contains(T data)
		{
			for (int i = 0; i < Count; i++)
				if (arrayStack[i].Equals(data)) return true;

			return false;
		}

		public void CopyTo(T[] arr, int index)
		{
			if (index < 0)
				throw new ArgumentOutOfRangeException("arrayIndex is less than zero");
			if (arr == null)
				throw new ArgumentNullException("array is null");
			if (arr.Length < Count + index)
				throw new ArgumentException("The number of elements in the source Stack<T> " +
				"is greater than the available space from arrayIndex to the end of the destination array.");
			for (int i = Count - 1 + index; i >= index; i--)
				arr[i] = arrayStack[i];
		}

		public void Clear()
		{
			arrayStack = new T[DEFAULT_CAPACITY];
			this.Count = 0;
		}

		public void TrimExcees()
		{
			if (Count > Capacity * 0.9) return;
			Capacity = Count;
			T[] arrayAdd = new T[Capacity];
			CopyTo(arrayAdd, 0);
			arrayStack = arrayAdd;
		}

		public IEnumerator<T> GetEnumerator()
		{
			int currentNum = Count - 1;
			while (currentNum >= 0)
			{
				yield return arrayStack[currentNum];
				currentNum--;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}