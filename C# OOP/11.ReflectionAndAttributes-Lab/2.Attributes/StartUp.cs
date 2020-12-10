using System;

namespace _2.Attributes
{
	[Author("Hristo Hristov")]
	class StartUp
	{
		[Author("Hristo Hristov")]
		static void Main()
		{
			var tracker = new Tracker();
			tracker.PrintMethodsByAuthor();
		}
	}
}
