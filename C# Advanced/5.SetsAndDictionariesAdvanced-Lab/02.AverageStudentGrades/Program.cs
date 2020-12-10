using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.AverageStudentGrades
{
	class Program
	{
		static void Main(string[] args)
		{
			int numberOfStudents = int.Parse(Console.ReadLine());

			var students = new Dictionary<string, List<double>>();

			for (int i = 0; i < numberOfStudents; i++)
			{
				string[] studentInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
				string name = studentInfo[0];
				double grade = double.Parse(studentInfo[1]);

				if (!students.ContainsKey(name))
				{
					students[name] = new List<double>();
				}

				students[name].Add(grade);
			}

			foreach (var kvp in students)
			{
				var name = kvp.Key;
				var grades = kvp.Value;
				var averageSum = grades.Average();

				Console.Write($"{name} -> ");
				foreach (var grade in grades)
				{
					Console.Write($"{grade:F2} ");
				}
				Console.WriteLine($"(avg: {averageSum:F2})");
			}
		}
	}
}
