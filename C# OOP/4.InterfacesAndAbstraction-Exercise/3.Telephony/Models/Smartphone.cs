using _3.Telephony.Contracts;
using _3.Telephony.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3.Telephony.Models
{
	public class Smartphone : ICallabe, IBrowseable
	{
		public string Call(string number)
		{
			if (!number.All(ch => char.IsDigit(ch)))
			{
				throw new InvalidNumberException();
			}

			return $"Calling... {number}";
		}

		public string Browse(string url)
		{
			if(url.Any(ch => char.IsDigit(ch)))
			{
				throw new InvalidURLException();
			}

			return $"Browsing: {url}!";
		}		
	}
}
