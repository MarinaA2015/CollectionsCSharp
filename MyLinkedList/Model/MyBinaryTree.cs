using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinkedList.Model
{
	class MyBinaryTree<T> : IEnumerable<T>
	{
		public NodeBT<T> Root;

		public MyBinaryTree(T data)
		{
			NodeBT<T> node = new NodeBT<T>(data);
			this.Root = node;

		}

		public IEnumerator<T> GetEnumerator()
		{
			LinkedList<T> forEnumerator = new LinkedList<T>();

			forEnumerator = InOrder(Root, forEnumerator);
			return forEnumerator.GetEnumerator();


		}

		private LinkedList<T> InOrder(NodeBT<T> node, LinkedList<T> enumLL)
		{

			if (node != null)
			{
				InOrder(node.Left, enumLL);
				enumLL.AddLast(node.Data);
				InOrder(node.Right, enumLL);
			}
			return enumLL;
		}


		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		
	}

}
