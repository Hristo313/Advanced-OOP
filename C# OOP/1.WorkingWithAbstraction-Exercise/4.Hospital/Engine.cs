using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4.Hospital
{
	public class Engine
	{
        private const int MAX_CAPACITY = 3;

		private readonly List<Department> departments;
		private readonly List<Doctor> doctors;

		public Engine()
		{
			this.departments = new List<Department>();
			this.doctors = new List<Doctor>();
		}

		public void Run()
		{
			string command = ParseInput();
			command = PrintOutput();
		}

		private string ParseInput()
		{
			string command = Console.ReadLine();

			while (command != "Output")
			{
				string[] tokens = command.Split();

				string departamentName = tokens[0];
				string doctorFirstName = tokens[1];
				string doctorLastName = tokens[2];
				string doctorFullName = doctorFirstName + " " + doctorLastName;

				string patientName = tokens[3];

				if (!this.DoctorExists(doctorFullName))
				{
					this.doctors.Add(new Doctor(doctorFirstName, doctorLastName));
				}

				if (!this.DeparmentExists(departamentName))
				{
					this.departments.Add(new Department(departamentName));
				}

				Department department = this.departments
					.FirstOrDefault(d => d.Name == departamentName);

				Doctor doctor = this.doctors
					.FirstOrDefault(d => d.FullName == doctorFullName);

				bool isFree = departments
					.Any(d => d.Rooms.Any(r => r.Count < MAX_CAPACITY));

				if (isFree)
				{
					Room firstFreeRoom = department
						.GetFirstFreeRoom();

					Patient patient = new Patient(patientName);

					firstFreeRoom.AddPatient(patient);
					doctor.AddPatientToDoctor(patient);
				}

				command = Console.ReadLine();
			}

			return command;
		}

		private string PrintOutput()
		{
			string command = Console.ReadLine();
			while (command != "End")
			{
				string[] args = command.Split();

				if (args.Length == 1)
				{
					var patients = this.departments
						.FirstOrDefault(d => d.Name == command)
						.Rooms
						.SelectMany(r => r.Patients);

					foreach (var patient in patients)
					{
						Console.WriteLine(patient);
					}
				}
				else if (args.Length == 2 && int.TryParse(args[1], out int roomNumber))
				{
					Room room = this.departments
						.FirstOrDefault(d => d.Name == command)
						.Rooms
						.FirstOrDefault(r => r.Number == roomNumber);

					string[] output = room
						.ToString()
						.Split(Environment.NewLine)
						.OrderBy(r => r)
						.ToArray();

					foreach (var patient in output)
					{
						Console.WriteLine(patient);
					}
				}
				else
				{
					string doctorFullName = args[0] + args[1];

					Doctor doctor = this.doctors
						.FirstOrDefault(d => d.FullName == doctorFullName);

					foreach (var patient in doctor.Patients)
					{
						Console.WriteLine(patient);
					}				
				}

				command = Console.ReadLine();
			}

			return command;
		}

		private bool DoctorExists(string fullName)
		{
            bool exists = this.doctors.Any(d => d.FullName == fullName);

            return exists;
		}

        private bool DeparmentExists(string name)
		{
            bool exists = this.departments.Any(d => d.Name == name);

            return exists;
		}
    }
}
