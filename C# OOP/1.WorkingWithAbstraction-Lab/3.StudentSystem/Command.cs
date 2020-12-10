using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace _3.StudentSystem
{
	public class Command
	{
		public string Name { get; set; }

		public string[] Arguments { get; set; }

		public static Command Parse(string text)
		{
			var parts = text.Split();

			if (parts.Length < 1)
			{
				return null;
			}

			return new Command
			{
				Name = parts[0],
			    Arguments = parts.Skip(1).ToArray()
			};
		}
	}
}
