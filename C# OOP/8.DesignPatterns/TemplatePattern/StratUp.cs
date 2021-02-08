using System;

namespace TemplatePattern
{
   public class StratUp
    {
        public static void Main()
        {
            Sourdough bread1 = new Sourdough();
            bread1.Make();

            TwelveGrain bread2 = new TwelveGrain();
            bread2.Make();

            WholeWheat bread3 = new WholeWheat();
            bread3.Make();
        }
    }
}
