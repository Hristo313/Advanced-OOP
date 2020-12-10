using System;
using System.IO;
using System.Linq;

namespace _05.SliceAFile
{
	class Program
	{
		static void Main(string[] args)
		{
			using var stream = new FileStream("text.txt", FileMode.OpenOrCreate);

			var length = stream.Length / 4 + 1;
			var buffer = new byte[length];

			for (int i = 0; i < 4; i++)
			{
				var bytesRead = stream.Read(buffer, 0, buffer.Length);

				if(bytesRead < buffer.Length)
				{
					buffer = buffer.Take(bytesRead).ToArray();
				}

				using var currentPartsStream = new FileStream($"Part-{i + 1}.txt", FileMode.Create);

				currentPartsStream.Write(buffer, 0, buffer.Length);
			}
		}
	}
}
