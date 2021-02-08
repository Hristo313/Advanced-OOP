using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypePattern
{
    public class Sandwich : SandwitchPrototype
    {
        private string bread;
        private string meat;
        private string cheese;
        private string veggies;

        public Sandwich(string bread, string meat, string cheese, string veggies)
        {
            this.bread = bread;
            this.meat = meat;
            this.cheese = cheese;
            this.veggies = veggies;
        }

        //Prototype pattern
        public override SandwitchPrototype Clone()
        {
            //Output
            string ingridientsString = this.GetIngridientsList();
            Console.WriteLine($"Cloning sadwich with ingridients: {ingridientsString}");

            return this.MemberwiseClone() as SandwitchPrototype;
        }

        //Only for output purposes
        private string GetIngridientsList()
        {
            return $"{this.bread}, {this.meat}, {this.cheese}, {this.veggies}";
        }
    }
}
