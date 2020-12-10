namespace Aqua_Shop
{
    using AquaShop.Core;
    using AquaShop.Core.Contracts;
    using System;

    public class StartUp
    {
        public static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();

            //Example Input
//AddAquarium SaltwaterAquarium Underworld
//AddAquarium FreshwaterAquarium Swamp
//AddFish Underworld FreshwaterFish Nemo Clownfish 13,40
//AddFish Underworld SaltwaterFish Nemo Clownfish 13,40
//AddAquarium FreshwaterAquarium Riverworld
//AddFish Riverworld FreshwaterFish Emerald Catfish 7,32
//AddFish Underworld SweetwaterFish Diamond Catfish 3,50
//AddDecoration Plant
//InsertDecoration Riverworld Plant
//InsertDecoration Underworld Plant
//AddDecoration Plant
//InsertDecoration Underworld Plant
//FeedFish Riverworld
//AddFish Riverworld FreshwaterFish  Species 20
//AddFish Riverworld FreshwaterFish Name  20
//AddFish Riverworld FreshwaterFish Name Species -10
//Report
//Exit
        }
    }
}
