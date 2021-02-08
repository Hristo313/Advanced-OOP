﻿using System;
using System.Collections.Generic;
using System.Text;

namespace _7.RawData
{
	public class Cargo
	{
		private int weight;
		private string type;

		public Cargo(int weight, string type)
		{
			this.Weight = weight;
			this.Type = type;
		}

		public int Weight { get; set; }

		public string Type { get; set; }
	}
}