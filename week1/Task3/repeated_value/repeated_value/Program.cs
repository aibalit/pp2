using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());// adding the method

			Method(n);

		}

		static void Method(int n)// main part 
		{
			string[] s = Console.ReadLine().Split(' '); //read numbers from input to array of string

			int[] arr = new int[n * 2];// creating second array with 2*n values

			int j = 0;//index of value
			for (int i = 0; i < s.Length; i++)
			{
				arr[i + j] = int.Parse(s[i]);// adding the value to array
				arr[i + j + 1] = int.Parse(s[i]);// adding copied vallue to array to the next cell
				j++;
			}

			foreach (int i in arr)// output the values of array
			{
				Console.Write($"{i} "); //this command allows you to use reserved word with result of problem
			}
		}
	}
}