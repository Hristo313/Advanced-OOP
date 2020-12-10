using _2.Attributes.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace _2.Attributes.Utinities
{
	public static class Validator
	{
		//Checks all object's properties for custom attributes and if all custom attributes are valid,
		//then the whole object is valid
		public static bool IsValid(object obj)
		{
			if(obj == null)
			{
				return false;
			}

			Type objType = obj.GetType();

			PropertyInfo[] properties = objType
				.GetProperties();

			//If all properties are valid with custom attributes -> Object is Valid
			//If one property is not valid for one of it's custom attributes -> Object is not Valid
			foreach (PropertyInfo property in properties)
			{
				MyValidationAttribute[] attributes = property
					.GetCustomAttributes()
					.Where(ca => ca is MyValidationAttribute)
					.Cast<MyValidationAttribute>()
					.ToArray();

				foreach (MyValidationAttribute attribute in attributes)
				{
					if(!attribute.IsValid(property.GetValue(obj)))
					{
						return false;
					}
				}
			}

			return true;
		}
	}
}
