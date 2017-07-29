using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLinkedList.Model
{
	class Person
	{
		private int Id { get; set; }
		private int Age { get; set; }
		private string Name { get; set; }
		private string City { get; set; }

		public Person(int id)
		{
			this.Id = id;
		}

		public Person(int id, int age, string name, string city)
		{
			this.Id = id;
			this.Age = age;
			this.Name = name;
			this.City = city;
		}

		public virtual void display()
		{
			Console.WriteLine( "Id: " + Id + " Age: " + Age + " Name: " + Name + " City: " + City);
		}

		public override string ToString()
		{
			return "Id: " + Id + " Age: " + Age + " Name: " + Name + " City: " + City;

		}

	}
}
