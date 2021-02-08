using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _3.Stack
{
	public class MyStack<T> : IEnumerable<T>
	{
		private List<T> items;

		public MyStack()
		{
			items = new List<T>();
		}

		public int Count => this.items.Count;

		public void Push(T item)
		{
			this.items.Add(item);
		}

		public T Pop()
		{
			T item = this.items[this.items.Count - 1]; //[^1]
			this.items.RemoveAt(this.items.Count - 1);
			return item;
		}

		public IEnumerator<T> GetEnumerator()
		{
			for (int i = this.items.Count - 1; i >= 0; i--)
			{
				yield return this.items[i];
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}
	}
}
