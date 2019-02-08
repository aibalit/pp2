using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prime_numbers
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine()); // read integer n

			int[] mas = new int[n]; // create array mas
			int[] mas2 = new int[n]; // create array mas2   

			string[] nums = Console.ReadLine().Split(new char[] { ',', ';', '#', ' ' }); //read numbers from input to array of string

			for (int i = 0; i < n; i++)
			{
				mas[i] = int.Parse(nums[i]); // convert from string to our array of integers
			}

			int k = 0; //  adding counter
			for (int i = 0; i < n; i++) 
			{
				for (int j = 1; j <= mas[i]; j++) // cycle of dividers
				{
					if (mas[i] % j == 0) // condition
					{
						k++; // adjunction for counter
					}
				}
				if (k == 2) // condition
				{
					mas2[i] = mas[i]; // result if condition is correct
				}
				else
					mas2[i] = 0; // another result 
				k = 0; // counter resfresh
			}

			for (int i = 0; i < n; i++)
			{
				if (mas2[i] != 0) // condition
					k++; // adjunction for counter
			}

			Console.WriteLine(k); // shows the counter

			for (int i = 0; i < n; i++)
			{
				if (mas2[i] != 0)
					Console.Write($"{mas2[i]} "); // this command allows you to use reserved word with result of problem
			}

			Console.ReadKey();

		}
	}
}