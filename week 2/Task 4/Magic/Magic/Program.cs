using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Magic
{
	class Program
	{
		static void Main(string[] args)
		{
			string fileName = "Stick.txt";
			string sourcePath = @"C:\Users\aibar\Desktop\c#\PP2\week 2\Task 4";// path of file
			string targetPath = @"C:\Users\aibar\Desktop\c#\PP2\week 2\Task 4\Magic";//path of file

			string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
			string destFile = System.IO.Path.Combine(targetPath, fileName);

			if (!System.IO.Directory.Exists(targetPath))
			{
				System.IO.Directory.CreateDirectory(targetPath);
			}


			System.IO.File.Copy(sourceFile, destFile, true);//copying file


			if (System.IO.Directory.Exists(sourcePath))

			{
				string[] files = System.IO.Directory.GetFiles(sourcePath);



				foreach (string s in files)// Copy the files and overwrite destination files if they already exist
				{
					fileName = System.IO.Path.GetFileName(s);
					destFile = System.IO.Path.Combine(targetPath, fileName);
					System.IO.File.Copy(s, destFile, true);

				}
			}
			else
			{
				Console.WriteLine("Source path does not exist!");
			}
			if (System.IO.File.Exists(@"C:\Users\aibar\Desktop\c#\PP2\week 2\Task 4\Stick.txt")) // conditing

			try
			{
				System.IO.File.Delete(@"C:\Users\aibar\Desktop\c#\PP2\week 2\Task 4\Stick.txt");// deleting file if it exists

			}
			catch (System.IO.IOException e)	
			{
				Console.WriteLine(e.Message);
				return;

			}

				
				
				
		}











	}
}
			

		 
			






	
