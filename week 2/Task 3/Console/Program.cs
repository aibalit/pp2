using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Console
{
	class Program
	{
		public static void Draw(FileSystemInfo[] files, int index)
		{
			Console.BackgroundColor = ConsoleColor.DarkRed;// creating console
			Console.Clear();
			for (int i = 0; i < files.Length; ++i)
			{
				if (i == index)
				{
					Console.BackgroundColor = ConsoleColor.DarkGray;
				}
				else
				{
					Console.BackgroundColor = ConsoleColor.Black;
				}

				if (files[i].GetType() == typeof(DirectoryInfo))
				{
					Console.ForegroundColor = ConsoleColor.White;
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.White;
				}
				Console.WriteLine(files[i].Name);
			}
		}
		static void Main(string[] args)
		{
			DirectoryInfo dirInfo = new DirectoryInfo(@"C:\");// this is a way of directory which i want to read
			FileSystemInfo[] files = dirInfo.GetFileSystemInfos();//give information

			int index = 0;

			Draw(files, index);

			bool quit = false;
			while (!quit)
			{
				ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();// bindint keys

				switch (consoleKeyInfo.Key)
				{
					case ConsoleKey.UpArrow:
						if (index == 0)
							index = files.Length - 1;
						else
							index--;
						Draw(files, index);
						break;
					case ConsoleKey.DownArrow:
						if (index == files.Length - 1)
							index = 0;
						else
							index++;
						Draw(files, index);
						break;
					case ConsoleKey.Enter:
						if (files[index].GetType() == typeof(DirectoryInfo)) //checking is it a folder
						{
							files = (files[index] as DirectoryInfo).GetFileSystemInfos();
							index = 0;
							Draw(files, index);
						}
						else
						{
							Console.BackgroundColor = ConsoleColor.White;
							Console.Clear();
							Console.ForegroundColor = ConsoleColor.Black;
							Console.WriteLine(File.ReadAllText(files[index].FullName));

							bool exit = false;
							while (!exit)
							{
								ConsoleKeyInfo consoleKeyInfo2 = Console.ReadKey();
								if ((consoleKeyInfo2.Key == ConsoleKey.Escape) || (consoleKeyInfo2.Key == ConsoleKey.Backspace))// waiting for escape of backspace
								{
									Draw(files, index);
									exit = true;
								}
							}
						}
						break;
					case ConsoleKey.Backspace:
						if (files[0].GetType() == typeof(DirectoryInfo))
						{
							files = (files[0] as DirectoryInfo).Parent.Parent.GetFileSystemInfos();//rewrite files from previous folder
							index = 0;
							Draw(files, index);
						}
						else
						{
							files = (files[0] as FileInfo).Directory.Parent.GetFileSystemInfos();// rewrite files from previous folder
							index = 0;
							Draw(files, index);
						}
						break;
					case ConsoleKey.Escape:
						quit = true;
						break;
				}

			}
		}
	}
}