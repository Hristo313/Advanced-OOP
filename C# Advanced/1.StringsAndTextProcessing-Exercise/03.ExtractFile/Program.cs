using System;

namespace _03.ExtractFile
{
	class Program
	{
		static void Main(string[] args)
		{
			string path = Console.ReadLine();

			int startIndexOfFile = path.LastIndexOf('\\') + 1;
			string file = path.Substring(startIndexOfFile);
			int startIndexOfExtension = file.LastIndexOf('.') + 1;

			string name = file.Substring(0, startIndexOfExtension - 1);//(0,8)-8 e br indeksi a ne do koi indeks
			string extension = file.Substring(startIndexOfExtension);

			Console.WriteLine($"File name: {name}");
			Console.WriteLine($"File extension: {extension}");
		}
	}
}