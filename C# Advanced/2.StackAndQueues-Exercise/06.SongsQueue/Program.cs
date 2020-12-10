using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _06.SongsQueue
{
	class Program
	{
		static void Main(string[] args)
		{
			string[] input = Console.ReadLine().Split(", ");
			Queue<string> songs = new Queue<string>(input);

			while (songs.Any())
			{
				string line = Console.ReadLine();
				string[] command = line.Split();

				if (command[0] == "Play")
				{
					songs.Dequeue();
				}
				else if (command[0] == "Add")
				{
					string newSong = line.Substring(4);

					if (!songs.Contains(newSong))
					{
						songs.Enqueue(newSong);
					}
					else
					{
						Console.WriteLine($"{newSong} is already contained!");
					}
				}
				else
				{
					Console.WriteLine(string.Join(", ", songs));
				}
			}

			Console.WriteLine("No more songs!");
		}
	}
}
