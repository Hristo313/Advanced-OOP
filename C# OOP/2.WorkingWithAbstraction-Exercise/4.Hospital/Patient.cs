namespace _4.Hospital
{
	public class Patient
	{
		public Patient(string name)
		{
			this.Name = name;
		}

		public string Name { get; }

		public override string ToString()
		{
			return this.Name;
		}
	}
}
