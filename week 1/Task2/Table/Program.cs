using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Table
{
	class Student
	{
		public string name;// three stings
		public string id;
		public string year;

		public void PrintInfo() // method
		{
			Console.WriteLine(name + " " + id + " " + year);// order of output
		}
	}

	class Program
	{
		static void Main(string[] args)
		{
			Student s = new Student
			{
				name = Console.ReadLine(),
				id = Console.ReadLine(),
				year = Console.ReadLine()
			};
			s.PrintInfo();
		}
	}
}