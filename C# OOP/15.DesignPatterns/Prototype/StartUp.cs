using System;

namespace PrototypePattern
{
    public class StartUp
    {
       public static void Main()
        {
            SandwichMenu menu = new SandwichMenu();

            //Initialize with default sandwiches
            menu["BLT"] = new Sandwich("Wheat", "Bacon", "", "Lettuce, Tomato");
            menu["Turkey"] = new Sandwich("Rye", "Turkey", "Swiss", "Lettuce, Onion, Tomato");

            //Now we can clone these sandwiches
            Sandwich sandwich1 = menu["BLT"].Clone() as Sandwich;
            Sandwich sandwich2 = menu["Turkey"].Clone() as Sandwich;
        }
    }
}
