using _3.Telephony.Contracts;
using _3.Telephony.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.Telephony.Models
{
	public class StationaryPhone : ICallabe
	{
		public string Call(string number)
		{
			if(!number.All(ch => char.IsDigit(ch)))
			{
				throw new InvalidNumberException();
			}

			return $"Dialing... {number}";
		}
	}
}
