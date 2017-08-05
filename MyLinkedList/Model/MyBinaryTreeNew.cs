using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinkedList.Model
{
	class MyBinaryTreeNew<T> : IEnumerable<T>
	{
		public NodeBT<T> Root;

		public MyBinaryTreeNew(T data)
		{
			NodeBT<T> node = new NodeBT<T>(data);
			this.Root = node;

		}

		public IEnumerator<T> GetEnumerator()
		{
			NodeBT<T> current = TheMostLeft(Root);
			NodeBT<T> last = TheMostRight(Root);
			while (!current.Equals(last))
			{
				yield return current.Data;
				if (current.Right != null)
					current = TheMostLeft(current.Right);
				else if (current.IsLeftChild())
					current = current.Parent;
				else if (current.IsRightChild())
					while (!current.IsLeftChild() && !current.IsHead())
						current = current.Parent;
				else if (current.IsHead())
					if (current.Right != null) yield break;
					else current = TheMostLeft(current.Right);

			}
			yield return last.Data;
		}

		private NodeBT<T> TheMostLeft(NodeBT<T> node)
		{
			if (node == null) return null;
			if (node.Left == null) return node;
			NodeBT<T> current = node;
			while (current.Left != null)
				current = current.Left;
			return current;
		}

		private NodeBT<T> TheMostRight(NodeBT<T> node)
		{
			if (node == null) return null;
			if (node.Right == null) return node;
			NodeBT<T> current = node;
			while (current.Right != null)
				current = current.Right;
			return current;
		}



		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
