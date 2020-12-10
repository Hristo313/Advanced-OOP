using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05.DirectoryTraversal
{
	class Program
	{
		static void Main(string[] args)
		{
			string path = Console.ReadLine();

			string[] files = Directory.GetFiles(path);

			var extensionFileInfo = new Dictionary<string, List<FileInfo>>();

			foreach (var file in files)
			{
				FileInfo info = new FileInfo(file);

				if (!extensionFileInfo.ContainsKey(info.Extension))
				{
					extensionFileInfo[info.Extension] = new List<FileInfo>();
				}

				extensionFileInfo[info.Extension].Add(info);
			}

			using var writer = new StreamWriter("../../../output.txt");

			foreach (var kvp in extensionFileInfo.OrderByDescending(x=> x.Value.Count).ThenBy(x=>x.Key))
			{
				string extension = kvp.Key;
				var info = kvp.Value;

				writer.WriteLine(extension);
				foreach (var fileInfo in info.OrderByDescending(x => x.Length))
				{
					string name = fileInfo.Name;
					double size = fileInfo.Length / 1024;

					writer.WriteLine($"--{name} - {size:F3}kb");
				}
			}
		}
	}
}
