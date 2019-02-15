using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triangle
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine()); // creating array

			for (int i = 0; i < n; i++) //1st cycle
			{
				for (int j = 0; j <= i; j++) //2nd cycle
				{
					Console.Write("[*]");
				}
				Console.WriteLine();
			}
		}
	}
}