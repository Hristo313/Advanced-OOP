using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _5.GenericCountMethodStrings
{
	public class Box<T> where T : IComparable
	{
		public Box(List<T> value)
		{
			this.Values = value;
		}

		public List<T> Values { get; set; }

		public int CompareElements(List<T> elements, T elementToCompare)
		{
			int counter = 0;

			foreach (var element in elements)
			{
				if (element.CompareTo(elementToCompare) == 1)
				{
					counter++;
				}
			}

			return counter;
		}
	}
}
