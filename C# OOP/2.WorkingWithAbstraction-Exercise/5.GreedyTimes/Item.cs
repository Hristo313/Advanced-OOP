using System;
using System.Collections.Generic;
using System.Text;

namespace _5.GreedyTimes
{
	public class Item
	{
        public string Name { get; protected set; }
        public long Quantity { get; protected set; }

        public void IncreaseValue(long value)
        {
            Quantity += value;
        }
    }
}
