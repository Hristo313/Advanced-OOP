namespace Counter_Strike
{
    using Counter_Strike.Core;
    using Counter_Strike.Core.Contracts;

    public class StratUp
    {
        public static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();

            //Example input
//AddGun Rafle Express 100
//AddGun Rafle Buffalo 100
//AddGun Rafle Assault 100
//AddGun Granate Invalid 100
//AddGun Pistol Kolibri 5
//AddGun Pistol Makarov 15
//AddGun Pistol Magnum 3
//AddGun Pistol  3
//AddPlayer Terrorist Shopoff 50 50 Express
//AddPlayer Terrorist Kris 50 50 Buffalo
//AddPlayer Terrorist  50 50 Express
//AddPlayer Terrorist Atanas 50 50 Invalid
//AddPlayer Terrorist Atanas -10 50 Express
//AddPlayer Terrorist Atanas 20 -50 Express
//AddPlayer CounterTerrorist John 50 50 Kolibri
//AddPlayer CounterTerrorist Peter 30 30 Makarov
//AddPlayer Player Invalid 30 30 Makarov
//StartGame
//Report
//Exit
        }
    }
}
