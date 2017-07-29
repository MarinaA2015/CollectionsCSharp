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
		private int Capacity; //{ get; set; }
		public int Count = 0;
		private T[] arrayStack;
		public const int DEFAULT_CAPACITY = 10;

		private void setCount(int count)
		{
			this.Count = count;			
		}

		public int getCount()
		{
			return Count;
		}
		
		public MyStack()
		{
			arrayStack = new T[Capacity];
			this.Capacity = DEFAULT_CAPACITY;
		}
		public MyStack(IEnumerable<T> coll)
		{
			arrayStack = new T[Capacity];
			this.Capacity = DEFAULT_CAPACITY;
			foreach (T data in coll)
				Push(data);
		}
		public T Peek()
		{
			if (Count == 0) throw new InvalidOperationException("The Stack<T> is empty");
			return arrayStack[Count-1];
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
			if (Count - 1 == Capacity) IncreaseCapacity();
			arrayStack[Count] = data;
		}

		private void IncreaseCapacity()
		{
			Capacity = Capacity * 2;
			T[] arrayAdd = new T[Capacity];
			CopyTo(arrayAdd, 0);
			arrayStack = arrayAdd;
		}

		public T[] ToArray() {
			T[] arr = new T[Count];
			for (int i = Count - 1; i >= 0; i--)
				arr[Count - 1 - i] = arrayStack[i];
			return arr;
		}

		public override string ToString() {
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
			for (int i = Count - 1+index; i >= index; i--)
					arr[i] = arrayStack[i];		
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
			throw new NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}
}
