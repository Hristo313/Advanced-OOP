using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace _1.ListyIterator
{
	public class ListyIterator<T> : IEnumerable<T>
	{
		private List<T> collection;
		private int currentIndex;

		public ListyIterator(List<T> collection)
		{
			this.collection = collection;
			this.currentIndex = 0;
		}

		public int Count => this.collection.Count;
	
		public bool Move()
		{
			if (this.HasNext())
			{
				this.currentIndex++;
				return true;
			}
					
			return false;
		}

		public bool HasNext()
		{
			if (this.currentIndex == this.Count - 1)
			{
				return false;
			}

			return true;
		}

		public void Print()
		{
			if (this.Count == 0)
			{
				throw new InvalidOperationException("Invalid Operation!");
			}

			Console.WriteLine(this.collection[this.currentIndex]);
		}

		public IEnumerator<T> GetEnumerator()
		{
			foreach (var element in collection)
			{
				yield return element;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}

}
