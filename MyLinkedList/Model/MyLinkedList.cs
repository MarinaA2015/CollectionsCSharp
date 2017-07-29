using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinkedList.Model
{
	class MyLinkedList<T> : IEnumerable<T>
	{
		public Node<T> Head = null;
		public Node<T> Tail = null;
		public uint Count = 0;

		public void AddHead(T data) {
			this.AddHead(new Node<T>(data));
		}

		public void AddHead(Node<T> node)
		{
			if (Head == null)
			{
				Head = node;
				Tail = node;
				Head.Next = null;
				Head.Prev = null;
			}
			else
			{
				node.Next = Head;
				Head.Prev = node;
				Head = node;
				Head.Prev = null;
			}

			Count++;
		}

		public void AddTail(T data)
		{
			this.AddTail(new Node<T>(data));
		}

		public void AddTail(Node<T> node)
		{
			if (Tail == null)
			{
				Head = node;
				Tail = node;
				Tail.Next = null;
				Tail.Prev = null;
			}
			else
			{
				Tail.Next = node;
				node.Prev = Tail;
				node.Next = null;
				Tail = node;
			}
			Count++;
		}

		public void AddAfter(Node<T> node, T data)
		{
			Node<T> newNode = new Node<T>(data);
			this.AddAfter(node, newNode);	
		}

		public void AddAfter(Node<T> node, Node<T> nodeNew)
		{
			if (nodeNew == null) throw new ArgumentNullException("newNode is null");
			Node<T> current = Head;
			while (current != null)
			{
				if (current.Equals(node))
				{
					if (current == Tail)
						{
						this.AddTail(nodeNew);
						return;
						}
					nodeNew.Next = current.Next;
					nodeNew.Prev = current;
					current.Next.Prev = nodeNew;
					current.Next = nodeNew;
					Count++;
					return;
				}
				current = current.Next;
			}
			throw new InvalidOperationException("node is not in the current LinkedList<T>");
		}

		public void AddBefore(Node<T> node, T data)
		{
			Node<T> newNode = new Node<T>(data);
			this.AddBefore(node, newNode);
		}

		public void AddBefore(Node<T> node, Node<T> nodeNew)
		{
			if (nodeNew == null) throw new ArgumentNullException("newNode is null");
			Node<T> current = Head;
			while (current != null)
			{
				if (current.Equals(node))
				{
					if (current == Head)
					{
						this.AddHead(nodeNew);
						return;
					}
					nodeNew.Prev = current.Prev;
					nodeNew.Next = current;
					current.Prev.Next = nodeNew;
					current.Prev = nodeNew;
					Count++;
					return;
				}
				current = current.Next;
			}
			throw new InvalidOperationException("node is not in the current LinkedList<T>");
		}

		public void Clear()
		{
			Head = null;
			Tail = null;
			Count = 0;
		}

		public bool Contains(T data) {
			return Find(data) != null;
		}

		public Node<T> Find(T data)
		{
			Node<T> current = Head;
			while (current != null)
			{
				if (current.Data.Equals(data)) return current;
				current = current.Next;
			}
			return null;
		}

		public Node<T> FindLast(T data)
		{
			Node<T> current = Tail;
			while (current != null)
			{
				if (current.Data.Equals(data)) return current;
				current = current.Prev;
			}
			return null;
		}

		public bool Remove(T data)
		{
			if (Find(data) == null) return false;
			this.Remove(Find(data));
			return true;
		}

		public void Remove(Node<T> node)
		{
			if (node == null) throw new ArgumentNullException("node is null");
			if (node == Head) this.RemoveHead();
			if (node == Tail) this.RemoveTail();
			Node<T> current = Head;
			while (current != null)
			{
				if (current.Equals(node))
				{
					current.Prev.Next = current.Next;
					current.Next.Prev = current.Prev;
					Count--;
					return;
				}
				current = current.Next;
			}
			throw new InvalidOperationException("node is not in the current LinkedList<T>");
		}

		public void RemoveHead()
		{
			if (Head == null) throw new InvalidOperationException("The LinkedList<T> is empty");
			Head = Head.Next;
			Head.Prev = null;
			Count--;
		}

		public void CopyTo(T[] arr, Int32 ind) {
			if (arr == null) throw new ArgumentNullException("array is null");
			if (ind < 0) throw new ArgumentOutOfRangeException("index is less than zero");
			if (ind + this.Count > arr.Length) throw new ArgumentException("The number of elements in the source MyLinkedList<T> is greater than the available space from index to the end of the destination array");
			Node<T> node = Head;
			for (int i = 0; i < Count; i++) {
				arr[ind + i] = node.Data;
				node = node.Next;
			}
		}

		

		public void RemoveTail()
		{
			if (Tail == null) throw new InvalidOperationException("The LinkedList<T> is empty");
			Tail = Tail.Prev;
			Tail.Next = null;
			Count--;
		}

		public override string ToString() {
			string res="";
			Node<T> node = Head;
			for (int i=0; i < Count; i++)
			{
				//Console.Write(node);
				res = res + node.Data.ToString()+" ";
				node = node.Next;
			}

			return res;
		}

		public IEnumerator<T>  GetEnumerator()
		{
			
			return new MyLLEnumerator<T>(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}


		
	}
}
