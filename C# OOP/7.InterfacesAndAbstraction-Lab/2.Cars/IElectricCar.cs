using System;
using System.Collections.Generic;
using System.Text;

namespace _2.Cars
{
	interface IElectricCar : ICar
	{
		int Battery { get; }
	}
}
