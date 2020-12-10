using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1.Library
{
	public class Library : IEnumerable<Book>
	{
		private SortedSet<Book> books;

		public Library(params Book[] books)
		{
			this.books = new SortedSet<Book>(books, new BookComparator());
		}

		public IEnumerator<Book> GetEnumerator()
		{
			//foreach (var book in books)
			//{
			//	yield return book;
			//}
			return new LibraryIterator(this.books.ToList());
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		private class LibraryIterator : IEnumerator<Book>
		{
			private List<Book> books;
			private int currentIndex;

			public LibraryIterator(List<Book> books)
			{
				this.Reset();
				this.books = books;
			}

			public Book Current
			{
				get
				{
					return this.books[this.currentIndex];
				}
			}

			object IEnumerator.Current => this.Current;

			public bool MoveNext()
			{
				this.currentIndex++;

				return this.currentIndex < this.books.Count;
			}

			public void Reset()
			{
				this.currentIndex = -1;
			}

			public void Dispose()
			{

			}
		}
	}
}
