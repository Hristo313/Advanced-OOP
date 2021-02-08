using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _10.SoftUniParking
{
	public class Parking
	{
		private List<Car> cars;
		private int capacity;

		public Parking(int capacity)
		{
			this.capacity = capacity;
			this.cars = new List<Car>();
		}

		public int Count
		{
			get
			{
				return cars.Count;
			}
		}

		public string AddCar(Car car)
		{
			string registrationNumber = car.RegistrationNumber;

			if (cars.Any(c => c.RegistrationNumber == registrationNumber))
			{
				return "Car with that registration number, already exists!";
			}

			if (cars.Count > capacity)
			{
				return "Parking is full!";
			}

			cars.Add(car);
			return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
		}

		public string RemoveCar(string registrationNumber)
		{
			foreach (var currentCar in cars)
			{
				if (currentCar.RegistrationNumber == registrationNumber)
				{
					cars.RemoveAll(c => c.RegistrationNumber == registrationNumber);
					return $"Successfully removed {registrationNumber}";
				}
			}

			return "Car with that registration number, doesn't exist!";
		}

		public Car GetCar(string registrationNumber)
		{
			foreach (var currentCar in cars)
			{
				if (currentCar.RegistrationNumber == registrationNumber)
				{
					return currentCar;
				}
			}
			return null;
		}

		public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers, Car car)
		{
			foreach (var registrationNumber in registrationNumbers)
			{
				if (car.RegistrationNumber == registrationNumber)
				{
					cars.RemoveAll(c => c.RegistrationNumber == registrationNumber);
				}
			}
		}
	}
}
