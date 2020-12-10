using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Library
{
	public class StartUp
	{
		public static void Main(string[] args)
		{
			Book bookOne = new Book("Animal Farm", 2003, "George Orwell");
			Book bookTwo = new Book("The Documents in the Case", 2002, "Dorothy Sayers", "Robert Eustace");
			Book bookThree = new Book("The Documents in the Case", 1930);

			Library library = new Library(bookOne, bookTwo, bookThree);

			foreach (var book in library)
			{
				Console.WriteLine(book);

				if (book.Authors.Any())
				{
					Console.WriteLine($"   Author: {string.Join(", ", book.Authors)}");
				}
			}
		}
	}
}
