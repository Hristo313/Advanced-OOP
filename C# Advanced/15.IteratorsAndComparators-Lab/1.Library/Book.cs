using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace _1.Library
{
	public class Book : IComparable<Book>
	{
		public Book(string title, int year, params string[] authors)
		{
			this.Title = title;
			this.Year = year;
			this.Authors = authors.ToList();
		}

		public string Title { get; set; }

		public int Year { get; set; }

		public List<string> Authors { get; set; }
		
		public int CompareTo(Book other) //For Exercise 2
		{
			var yearComparison = this.Year.CompareTo(other.Year);

			if (yearComparison == 0)
			{
				return this.Title.CompareTo(other.Title);
			}

			return yearComparison;
		}

		public override string ToString()
		{
			return $"Book: {this.Title} -> {this.Year} ";
		}
	}
}
