using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace _1.Library
{
	public class BookComparator : IComparer<Book> // For Exercise 3
	{
		public int Compare(Book firstBook, Book secondBook)
		{
			var titleComparison = firstBook.Title.CompareTo(secondBook.Title);

			if (titleComparison == 0)
			{
				return secondBook.Year.CompareTo(firstBook.Year);
			}

			return titleComparison;
		}
	}
}
