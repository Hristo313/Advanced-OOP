using System;
using System.Collections.Generic;
using System.Text;

namespace _2.PointInRectangle
{
	public class Rectangle
	{
		public Rectangle(Point topLeft, Point bottomRight)
		{
			this.TopLeft = topLeft;
			this.BottomRight = bottomRight;
		}

		public Point TopLeft { get; set; }

		public Point BottomRight { get; set; }

		public bool Contains(Point point)
		{
			bool isInHorizontal = this.TopLeft.X <= point.X
				&& point.X <= this.BottomRight.X;

			bool isInVertical = this.BottomRight.Y <= point.Y
				&& point.Y <= this.TopLeft.Y;

			return isInHorizontal && isInVertical;
		}
	}
}
