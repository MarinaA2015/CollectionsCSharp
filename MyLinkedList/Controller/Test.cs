using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyLinkedList.Model;



namespace MyLinkedList
{
	class Test
	{


		static void Main(string[] args)
		{

			MyLinkedList<int> myLLInt = new MyLinkedList<int>();
			MyLinkedList<Person> myLLPerson = new MyLinkedList<Person>();
			MyStack<Person> myStackPerson = new MyStack<Person>();
			Person vasya = new Person(12345, 32, "Vasya", "Netanya");
			Person moshe = new Person(54321, 29, "Moshe", "Lod");
			Person helen = new Person(32323, 43, "Helen", "Rehovot");
			Person shir = new Person(67895, 16, "Shir", "Netanya");
			Person[] arrayPersons = new Person[4] { vasya, moshe, helen, shir };
			Console.WriteLine();
			Console.WriteLine("----------------------MyLinkedList<int> verification -----------------------");
			Console.WriteLine("----------- AddTail, AddHead, AddAfter, AddBefore verifications-----------");
			myLLInt.AddTail(25);
			myLLInt.AddHead(20);
			myLLInt.AddHead(15);
			myLLInt.AddAfter(myLLInt.Tail, 30);
			myLLInt.AddAfter(myLLInt.Tail.Prev, 27);
			myLLInt.AddBefore(myLLInt.Head, 10);
			myLLInt.AddAfter(myLLInt.Head.Next, 17);

			Console.WriteLine(myLLInt.ToString());
			Console.WriteLine();
			Console.WriteLine("---------------Contains, Find verifications -------------");
			Node<int> node = myLLInt.Head;
			for (int i = 0; i < myLLInt.Count; i++)
			{
				Console.WriteLine("Contains " + node.Data + " verification: " + myLLInt.Contains(node.Data));
				Console.WriteLine("Find " + node.Data + " verification: " + myLLInt.Find(node.Data).Equals(node));
				node = node.Next;
			}
			Console.WriteLine();
			Console.WriteLine("----------------- Remove verification ---------------------");
			myLLInt.RemoveHead();
			myLLInt.RemoveTail();
			myLLInt.Remove(myLLInt.Head.Next);
			myLLInt.Remove(myLLInt.Tail.Prev);
			Console.WriteLine(myLLInt);
			Console.WriteLine();
			Console.WriteLine("----------------- CopyTo verification --------------------");
			int[] arr = new int[7];
			myLLInt.CopyTo(arr, 2);
			for (int i = 0; i < arr.Length; i++)
				Console.WriteLine(arr[i]);
			Console.WriteLine();
			Console.WriteLine("---------------------foreach--LinkedList<Person>-----------------");

			myLLPerson.AddHead(vasya);
			myLLPerson.AddTail(moshe);
			myLLPerson.AddTail(helen);

			foreach (Person prs in myLLPerson)
			{
				Console.WriteLine(prs);
			}
			Console.WriteLine();
			Console.WriteLine("---------------------foreach--LinkedList<int>-----------------");
			foreach (int num in myLLInt)
			{
				Console.WriteLine(num);
			}
			Console.WriteLine();
			Console.WriteLine("--------------------- Stack Verification<Person>----------------");

			myStackPerson = fillMyStack(arrayPersons, myStackPerson);
			Console.WriteLine();
			Console.WriteLine("----------------------Peek() Pop() Verification-----------------");

			Console.WriteLine();
			int iterations = myStackPerson.Count;
			for (int i = 0; i < iterations; i++)
				Console.WriteLine("Person: " + myStackPerson.Peek() + " : "
					+ myStackPerson.Peek().Equals(myStackPerson.Pop()));
			Console.WriteLine();
			Console.WriteLine("------------------------Capacity, Constructor with IEnumerable, foreach-----------------");
			myStackPerson = new MyStack<Person>(arrayPersons);
			myStackPerson = fillMyStack(arrayPersons, myStackPerson);
			myStackPerson = fillMyStack(arrayPersons, myStackPerson);

			Console.WriteLine("Count: " + myStackPerson.Count);
			foreach (Person person in myStackPerson)
				Console.WriteLine(person);

			Console.WriteLine();
			Console.WriteLine("------------------------Clear()-----------------------------");
			myStackPerson.Clear();
			foreach (Person person in myStackPerson)
				Console.WriteLine(person);
			myStackPerson.Push(vasya);
			myStackPerson.Push(moshe);
			foreach (Person person in myStackPerson)
				Console.WriteLine(person);



			/*Console.Writeln("----------------TrimExcees verification--------------");
			Console.WriteLine("Capacity: " + myStackPerson.Capacity);
			myStackPerson.TrimExcees();
			Console.WriteLine("Capacity: " + myStackPerson.Capacity);*/
			//Console.WriteLine(myStackPerson.Peek());

			Console.WriteLine("----------------------Queue: Constructors verification-----------------------------------------------");
			Console.WriteLine();

			MyQueue<Person> myQ = new MyQueue<Person>(arrayPersons);
			foreach (Person prs in myQ)
				Console.WriteLine(prs);
			Console.WriteLine("MyQ - Count: " + myQ.Count + " Capacity: " + myQ.Capacity);
			MyQueue<Person> myQ2 = new MyQueue<Person>(3);
			MyQueue<int> myQ3 = new MyQueue<int>();
			Console.WriteLine("MyQ2 - Count: " + myQ2.Count + " Capacity: " + myQ2.Capacity);
			Console.WriteLine("MyQ3 - Count: " + myQ3.Count + " Capacity: " + myQ3.Capacity);

			Console.WriteLine();
			Console.WriteLine("----------------------Queue: Enqueue, dequeue, peek, increasing capacity, treemExcees verification----------");
			Console.WriteLine();

			Console.WriteLine("---------MyQ2--------");
			Console.WriteLine("MyQ2 - Count: " + myQ2.Count + " Capacity: " + myQ2.Capacity);
			foreach (Person prs in arrayPersons)
				myQ2.Enqueue(prs);
			foreach (Person prs in myQ2)
				Console.WriteLine(prs);
			Console.WriteLine("MyQ2 - Count: " + myQ2.Count + " Capacity: " + myQ2.Capacity);
			Console.WriteLine("---------MyQ--------");
			Console.WriteLine("MyQ - Count: " + myQ.Count + " Capacity: " + myQ.Capacity);
			for (int i = 0; i < 4; i++)
			{
				Console.WriteLine("Iteration#" + i);
				Console.WriteLine("Peek/Enqueue/Dequeue: " + myQ.Peek());
				myQ.Enqueue(myQ.Dequeue());
				foreach (Person prs in myQ)
					Console.WriteLine(prs);
				Console.WriteLine("MyQ - Count: " + myQ.Count + " Capacity: " + myQ.Capacity);
				Console.WriteLine();
			}
			Console.WriteLine("Vasya was added, capacity has to be changed");
			myQ.Enqueue(vasya);
			Console.WriteLine("MyQ - Count: " + myQ.Count + " Capacity: " + myQ.Capacity);
			myQ.TrimExcees();
			Console.WriteLine("TreemExcees -> MyQ - Count: " + myQ.Count + " Capacity: " + myQ.Capacity);
			Console.WriteLine();
			Console.WriteLine("----------------------Queue: Clear verification----------");
			Console.WriteLine();
			Console.WriteLine("MyQ - Count: " + myQ.Count + " Capacity: " + myQ.Capacity);
			foreach (Person prs in myQ)
				Console.WriteLine(prs);
			myQ.Clear();
			Console.WriteLine("MyQ - Count: " + myQ.Count + " Capacity: " + myQ.Capacity);
			foreach (Person prs in myQ)
				Console.WriteLine(prs);


			Console.ReadKey();
		}

		private static MyStack<T> fillMyStack<T>(T[] array, MyStack<T> myStack)
		{
			for (int i = 0; i < array.Length; i++)
				myStack.Push(array[i]);
			return myStack;
		}
	}
}
