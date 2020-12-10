using System;
using System.Collections.Generic;
using System.Text;

namespace _2.Attributes.Attributes
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
	public abstract class MyValidationAttribute : Attribute
	{
		//Accepts property value and returns boolean dependant on it's validity
		public abstract bool IsValid(object obj);
	}
}
