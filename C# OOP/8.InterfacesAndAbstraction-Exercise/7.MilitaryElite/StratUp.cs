using _7.MilitaryElite.Core;
using _7.MilitaryElite.Core.Contracts;
using _7.MilitaryElite.IO;
using _7.MilitaryElite.IO.Contracts;
using System;

namespace _7.MilitaryElite
{
	public class StratUp
	{
		public static void Main(string[] args)
		{
			IReader reader = new ConsoleReader();
			IWritter writter = new ConsoleWritter();

			IEngine engine = new Engine(reader, writter);
			engine.Run();

//Private 1 Pesho Peshev 22,22
//Commando 13 Stamat Stamov 13,1 Airforces
//Private 222 Toncho Tonchev 80,08
//LieutenantGeneral 3 Joro Jorev 100 222 1
//End
		}
	}
}
