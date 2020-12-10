using System;
using System.Collections.Generic;
using System.Text;

namespace _1.ClassBoxData
{
	public class Box
	{
		private const double SIDE_MIN = 0;

		private double length;
		private double width;
		private double height;

		public Box(double length, double width, double height)
		{
			this.Length = length;
			this.Width = width;
			this.Height = height;
		}

		public double Length 
		{
			get
			{
				return this.length;
			}
			private set
			{
				if(value <= SIDE_MIN)
				{
					throw new ArgumentException("Length cannot be not possitive number!");
				}

				this.length = value;
			}
		}

		public double Width
		{
			get
			{
				return this.width;
			}
			private set
			{
				if (value <= SIDE_MIN)
				{
					throw new ArgumentException("Width cannot be not possitive number!");
				}

				this.width = value;
			}
		}

		public double Height
		{
			get
			{
				return this.height;
			}
			private set
			{
				if (value <= SIDE_MIN)
				{
					throw new ArgumentException("Height cannot be not possitive number!");
				}

				this.height = value;
			}
		}

		public double SurfaceArea()
		{
			return 2 * (this.Length * this.Width
				      + this.Length * this.Height
				      + this.Width * this.Height);
		}

		public double LiteralSurfaceArea()
		{
			return 2 * this.Height * (this.Length + this.Width);
		}

		public double Volume()
		{
			return this.Length * this.Width * this.Height;
		}
	}
}
