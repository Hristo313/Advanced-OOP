using System;
using System.IO;

namespace _04.CopyBinaryFile
{
	class Program
	{
		static void Main(string[] args)
		{
			using FileStream reader = new FileStream("copyMe.png", FileMode.Open);
			using FileStream writer = new FileStream("../../../copied.png", FileMode.Create);

			byte[] buffer = new byte[4096];

			while(true)
			{
				int bytesRead = reader.Read(buffer, 0 , buffer.Length);

				if(bytesRead == 0)
				{
					break;
				}

				writer.Write(buffer, 0, buffer.Length);
			}
		}
	}
}
