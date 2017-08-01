namespace MyLinkedList.Model
{
	class NodeBT<T>
	{
		public T Data { get; set; }
		public NodeBT<T> Left { get; set; }
		public NodeBT<T> Right { get; set; }

		public NodeBT(T data)
		{
			this.Data = data;
		}
	}
}