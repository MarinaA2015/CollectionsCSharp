using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinkedList.Model
{
	class MyStackEnumerator<T> : IEnumerator<T>
	{
		private T[] arrayStack;
		private int count;
		private int index;
		public T Current
		{
			get
			{
					return arrayStack[index];
				
			}
		}
		
		public MyStackEnumerator(T[] arrayStack, int count)
		{
			this.arrayStack = arrayStack;
			this.count = count;
			this.index = count;

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
			if (index > 0)
			{
				index--;
				return true;
			}
			return false;
		}

		public void Reset()
		{
			index = count;
		}
	}
}
