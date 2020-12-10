namespace _3.StudentSystem
{
	public class Student
	{
        public Student(string name, int age, double grade)
        {
            this.Name = name;
            this.Age = age;
            this.Grade = grade;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public double Grade { get; set; }

		public override string ToString()
		{
		    var student = $"{this.Name} is {this.Age} years old.";

			if (this.Grade >= 5.00)
			{
				student += " Excellent student.";
			}
			else if (this.Grade < 5.00 && this.Grade >= 3.50)
			{
				student += " Average student.";
			}
			else
			{
				student += " Very nice person.";
			}

			return student;
		}
	}
}
