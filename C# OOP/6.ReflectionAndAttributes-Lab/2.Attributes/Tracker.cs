using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _2.Attributes
{
	public class Tracker
	{
		public void PrintMethodsByAuthor()
		{
			var type = typeof(StartUp);
			var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

			foreach (var method in methods)
			{
				if (method.CustomAttributes.Any(n => n.AttributeType == typeof(AuthorAttribute)))
				{
					var attributes = method.GetCustomAttributes(false);

					foreach (AuthorAttribute attribute in attributes)
					{
						Console.WriteLine($"{method.Name} is written be {attribute.Name}");
					}
				}
			}
		}
	}
}
