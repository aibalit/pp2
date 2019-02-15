using Next_level_console;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Next_level_console
{
	class MyProgram
	{
		public static void Main(string[] args)
		{
			DirectoryInfo dirInfo = new DirectoryInfo(@"C:\"); // open new folder with given path

			FileSystemInfo[] files = dirInfo.GetFileSystemInfos(); // write folder's elements to array

			int index = 0; // selected item

			Options.Keys(index, files); // waiting a key
		}
	}

	class Advanced_options
	{
		public static DirectoryInfo dirInfo = new DirectoryInfo(@"C:\");

		public static void StartPage(FileSystemInfo[] files, int index)
		{
			Console.BackgroundColor = ConsoleColor.Black;
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine(files[index].Name);
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("\nSelect the options \n");// options
			Console.WriteLine("Press R to rename"); // options
			Console.WriteLine("Press D to delete");// options
			Console.WriteLine("Press Backspace to go back \n");// options

			ConsoleKeyInfo consoleKeyInfo;
			do
			{
				consoleKeyInfo = Console.ReadKey();
				switch (consoleKeyInfo.Key)
				{
					case (ConsoleKey.R):
						
						{
							Console.Clear();
							Console.WriteLine("Enter new name");
							if (files[index].GetType() == typeof(DirectoryInfo))
							{
								Directory.Move(files[index].FullName, (files[index] as DirectoryInfo).Parent.FullName + @"\" + Console.ReadLine()); //renaming the folder
								Console.WriteLine("\nFolder renamed! \n\nPress Backspace to go back \n");
								files = (files[index] as DirectoryInfo).Parent.GetFileSystemInfos(); //refresh the directory
								index = 0;
							}
							else
							{
								File.Move(files[index].FullName, (files[index] as FileInfo).Directory.FullName + @"\" + Console.ReadLine() + ".txt"); //renaming the file
								Console.WriteLine("\nFile Renamed! \n\nPress Backspace to go back \n");
								files = (files[index] as FileInfo).Directory.GetFileSystemInfos(); //refresh the directory
								index = 0;
							}
						}
						break;

					case (ConsoleKey.D):
						
						{
							Console.Clear();
							Console.WriteLine("Press Enter to delete");
							consoleKeyInfo = Console.ReadKey();
							if (consoleKeyInfo.Key == ConsoleKey.Enter)
							{
								if (files[index].GetType() == typeof(DirectoryInfo))
								{
									Options.Path = (files[index] as DirectoryInfo).Parent.FullName; //remember path of the folder
									dirInfo = new DirectoryInfo(Options.Path); //changing directory to the choosen one
									Directory.Delete(files[index].FullName, true); // deleting folder
									files = dirInfo.GetFileSystemInfos();
									Options.Keys(index, files);
								}
								else
								{
									Options.Path = (files[index] as FileInfo).Directory.FullName; //remember path of the folder
									dirInfo = new DirectoryInfo(Options.Path); //changing directory to the choosen one
									File.Delete(files[index].FullName); // deleting the file
									files = dirInfo.GetFileSystemInfos();
									Options.Keys(index, files);
								}
							}
							else
								Options.Keys(index, files);
						}
						break;

				}
			} while (consoleKeyInfo.Key != ConsoleKey.Backspace);

			Options.Keys(index, files);
		}

	}
}


class Options
	{
		public static string Path;
		

		public static void Keys(int index, FileSystemInfo[] files)
		{
			Draw(index, files); // show elements pf the folder

			ConsoleKeyInfo consoleKeyInfo; //new key
			bool exit = false; // variable for exit from program
			do
			{
				consoleKeyInfo = Console.ReadKey(); // read key
				switch (consoleKeyInfo.Key)
				{
					case ConsoleKey.UpArrow:
						if (index == 0) // for upper bound
							index = files.Length - 1;
						else
							index--;
						Draw(index, files);
						break;

					case ConsoleKey.DownArrow:
						if (index == files.Length - 1) // for lower bound
							index = 0;
						else
							index++;
						Draw(index, files);
						break;

					case ConsoleKey.Enter:
						if (files[index].GetType() == typeof(DirectoryInfo)) // checking is it folder
						{
							if ((files[index] as DirectoryInfo).GetFileSystemInfos().Length == 0) // if folder is empty
							{
								Draw(index, (files[index] as DirectoryInfo).GetFileSystemInfos());
							}
							else
							{
								files = (files[index] as DirectoryInfo).GetFileSystemInfos();
								index = 0;
								Draw(index, files);
							}
						}
						else
						{
							Console.BackgroundColor = ConsoleColor.White;
							Console.Clear();
							Console.ForegroundColor = ConsoleColor.Black;
							Console.WriteLine(File.ReadAllText(files[index].FullName)); // reading text from the file

							Console.ForegroundColor = ConsoleColor.DarkBlue;
							Console.WriteLine("\nPress Backspace to go back");

							ConsoleKeyInfo consoleKeyInfo2;
							do
							{
								consoleKeyInfo2 = Console.ReadKey();
							} while (consoleKeyInfo2.Key != ConsoleKey.Backspace); //waiting backspace to exit

							Options.Draw(index, files);
						}
						break;

					case ConsoleKey.Backspace:
						try
						{
							if (files[0].GetType() == typeof(DirectoryInfo))
							{
								files = (files[0] as DirectoryInfo).Parent.Parent.GetFileSystemInfos(); //rewrite files to previous folder
								index = 0;
								Draw(index, files);
							}
							else
							{
								files = (files[0] as FileInfo).Directory.Parent.GetFileSystemInfos(); //rewrite files to previous folder
								index = 0;
								Draw(index, files);
							}
							break;
						}
						catch (Exception) //exception for empty folder
						{
							Options.Keys(index, files);
							throw;
						}


					case ConsoleKey.H:
						Advanced_options.StartPage(files, index);
						break;

					case ConsoleKey.Escape:
						exit = true; //exit from the program
						break;
				}
			} while (!exit);
		}

		public static void Draw(int index, FileSystemInfo[] files)
		{
			Console.BackgroundColor = ConsoleColor.Black;
			Console.Clear();
			for (int i = 0; i < files.Length; ++i)
			{
				if (i == index)
				{
					Console.BackgroundColor = ConsoleColor.DarkBlue;
				}
				else
				{
					Console.BackgroundColor = ConsoleColor.Black;
				}

				if (files[i].GetType() == typeof(DirectoryInfo))
				{
					Console.ForegroundColor = ConsoleColor.Red;
				}
				else
				{
					Console.ForegroundColor = ConsoleColor.White;
				}
				Console.WriteLine(files[i].Name);
			}
			Console.WriteLine();
			Console.ForegroundColor = ConsoleColor.Green;
			Console.BackgroundColor = ConsoleColor.Black;
			Console.WriteLine("Press Enter to open, Press Backspace to go back, Press Ecs to exit");
			Console.WriteLine("Press h for advanced options \n");
		}
	}

