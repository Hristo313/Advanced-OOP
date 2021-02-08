using System;
using System.Collections.Generic;
using System.Text;

namespace CompositePattern
{
    public abstract class GiftBase
    {
        private string name;
        private int price;

        public GiftBase(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name 
        {
            get
            {
                return this.name;
            }                
            protected set
            {
                this.name = value;
            }
        }

        public int Price
        {
            get
            {
                return this.price;
            }
            protected set
            {
                this.price = value;
            }
        }

        public abstract int CalculateTotalPrice();
    }
}
