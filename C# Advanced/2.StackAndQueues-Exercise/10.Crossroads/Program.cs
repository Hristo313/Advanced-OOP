using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _10.Crossroads
{
	class Program
	{
		static void Main(string[] args)
		{
			int greenLightInterval = int.Parse(Console.ReadLine());
			int freeWindowInterval = int.Parse(Console.ReadLine());
			Queue<string> cars = new Queue<string>();

			int carPassed = 0;
			bool crash = false;
			int hitIndex = 0;
			string crashedCar = "";

			while (true)
			{
				string command = Console.ReadLine();

				if (command == "END")
				{
					break;
				}

				if (command == "green")
				{
					int currentGreenLight = greenLightInterval;

					while (cars.Any() && currentGreenLight > 0)
					{
						string currentCar = cars.Peek();
						int carLength = currentCar.Length;

						if (carLength <= currentGreenLight)
						{
							currentGreenLight -= carLength;
							carPassed++;
							cars.Dequeue();
						}
						else
						{
							carLength -= currentGreenLight;

							if (carLength <= freeWindowInterval)
							{
								carPassed++;
								cars.Dequeue();
							}
							else
							{
								crash = true;
								crashedCar = currentCar;
								hitIndex = currentGreenLight + freeWindowInterval;
								break;
							}
						}
					}
				}
				else
				{
					cars.Enqueue(command);
				}

				if (crash)
				{
					break;
				}
			}

			if (crash)
			{
				Console.WriteLine("A crash happened!");
				Console.WriteLine($"{crashedCar} was hit at {crashedCar[hitIndex]}.");
			}
			else
			{
				Console.WriteLine("Everyone is safe.");
				Console.WriteLine($"{carPassed} total cars passed the crossroads.");
			}
		}
	}
}
