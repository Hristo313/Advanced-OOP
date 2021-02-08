using System;
using System.Collections.Generic;
using System.Text;

namespace _2.Attributes
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
	public class AuthorAttribute : Attribute
	{
		public AuthorAttribute(string name)
		{
			this.Name = name;
		}

		public string Name { get; set; }
	}
}
