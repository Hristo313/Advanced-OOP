using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1.Box
{
	public class Box<T>
	{
		private List<T> data;

		public Box()
		{
			this.data = new List<T>();
		}

		public int Count
		{
			get
			{
				return this.data.Count;
			}
		}

		public void Add(T element)
		{
			this.data.Add(element);
		}

		public T Remove()
		{
			var item = this.data.Last();
			this.data.RemoveAt(this.data.Count - 1);
			return item;
		}	
	}
}
