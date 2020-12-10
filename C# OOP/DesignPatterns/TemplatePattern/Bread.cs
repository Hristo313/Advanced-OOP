using System;
using System.Collections.Generic;
using System.Text;

namespace TemplatePattern
{
    public abstract class Bread
    {
        public abstract void MixIngridients();

        public abstract void Bake();

        public virtual void Slice()
        {
            Console.WriteLine($"Slicing the {this.GetType().Name} bread!");
        }

        //Template method -> For any type of bread is valid
        public void Make()
        {
            this.MixIngridients();
            this.Bake();
            this.Slice();
        }
    }
}
