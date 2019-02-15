using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stay_prime
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] s = File.ReadAllText(@"C:\Users\aibar\Desktop\c#\PP2\week 2\Task 2\input.txt").Split(' '); // reading from textfile

			int[] mas = new int[s.Length]; // two strings
			int[] mas2 = new int[s.Length];  

			for (int i = 0; i < s.Length; i++)
			{
				mas[i] = int.Parse(s[i]); 
			}

			int c = 0; 
			for (int i = 0; i < s.Length; i++)// just conditions of prime numbers

			{
				for (int j = 1; j <= mas[i]; j++)
				{
					if (mas[i] % j == 0)
					{
						c++;
					}
				}
				if (c == 2)
				{
					mas2[i] = mas[i];
				}
				else
					mas2[i] = 0;
				c = 0;
			}

			for (int i = 0; i < s.Length; i++)
			{
				if (mas2[i] != 0)
					c++;
			}

			using (FileStream fs = new FileStream(@"C:\Users\aibar\Desktop\c#\PP2\week 2\Task 2\output.txt", FileMode.Create, FileAccess.Write))// creating file to output
			{
				using (StreamWriter wr = new StreamWriter(fs))// writing output
				{
					for (int i = 0; i < s.Length; i++)
					{
						if (mas2[i] != 0)
							wr.Write($"{mas2[i]} ");
					}
				}

			}
		}
	}
}