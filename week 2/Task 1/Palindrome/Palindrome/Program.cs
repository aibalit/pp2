using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace palindromecheck
{
	class Program
	{
		static void Main(string[] args)
		{

			string s2;

			string s = File.ReadAllText(@"C:\Users\aibar\Desktop\c#\Lab 2 pp2\Palindrome\Palindrome\text1.txt");// reading from textfile
			char[] ch = s.ToCharArray();// reversing the array

			Array.Reverse(ch);// reversing the array
			s2 = new string(ch);// s2 is the new reversed string

			bool b = s.Equals(s2, StringComparison.OrdinalIgnoreCase);// compare two strings
			if (b == true)
			{
				Console.WriteLine("YES");
			}
			else
			{
				Console.WriteLine("NO");
			}
			
		}
	}
}