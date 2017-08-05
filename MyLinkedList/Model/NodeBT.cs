using System;
namespace MyLinkedList.Model
{
	class NodeBT<T>
	{
		public T Data { get; set; }
		public NodeBT<T> Parent { get; set; }
		public NodeBT<T> Left { get; set; }
		public NodeBT<T> Right { get; set; }

		public NodeBT(T data)
		{
			this.Data = data;
		}

		public Boolean IsHead()
		{
			return this.Parent == null;
		}

		public Boolean IsRightChild()
		{
			return !IsHead() && Parent.Right.Equals(this);
		}

		public Boolean IsLeftChild()
		{
			return !IsHead() && Parent.Left.Equals(this);
		}
	}
}