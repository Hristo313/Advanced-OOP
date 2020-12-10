using System;
using System.IO.Compression;

namespace _06.ZipandExtract
{
	class Program
	{
		static void Main(string[] args)
		{
			ZipFile.CreateFromDirectory(@"..\..\..\myzip.zip", @"C:\VS\FMI\Снимки за документи\myArchive.zip");
			ZipFile.ExtractToDirectory(@"C:\VS\FMI\Снимки за документи\myArchive.zip", @"C:\VS\FMI\Снимки за документи");
		}
	}
}
