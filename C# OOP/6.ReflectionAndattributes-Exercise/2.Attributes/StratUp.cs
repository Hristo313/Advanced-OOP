using _2.Attributes.Models;
using _2.Attributes.Utinities;
using System;
using System.ComponentModel.DataAnnotations;
using Validator = _2.Attributes.Utinities.Validator;

namespace _2.Attributes
{
	public class StratUp
	{
		public static void Main(string[] args)
		{
			var person = new Person("Hristo Hristov", 33);

			bool isValidEntity = Validator.IsValid(person);

			Console.WriteLine(isValidEntity);
		}
	}
}
