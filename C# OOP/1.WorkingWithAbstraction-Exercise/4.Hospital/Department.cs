using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4.Hospital
{
	public class Department
	{
		private const int MAX_CAPACITY = 3;

		private readonly List<Room> rooms;

		private Department()
		{
			this.rooms = new List<Room>();
			this.InitializeRooms();
		}

		public Department(string name) : this()
		{
			this.Name = name;
		}

		public string Name { get; }

		public IReadOnlyCollection<Room> Rooms => this.rooms;

		public Room GetFirstFreeRoom()
		{
			return this.rooms.First(rooms => rooms.Count < MAX_CAPACITY);
		}

		private void InitializeRooms()
		{
			for (int i = 1; i < 20; i++)
			{
				this.rooms.Add(new Room(i));
			}
		}
	}
}
