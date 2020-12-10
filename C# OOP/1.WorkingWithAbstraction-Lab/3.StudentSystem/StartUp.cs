using System;

namespace _3.StudentSystem
{
	public class StartUp
	{
		public static void Main()
		{
			var studentData = new StudentData();
			var engine = new Engine(studentData);

			engine.Process();
		}
	}
}
