namespace Counter_Strike.Models.Guns
{
    public class Pistol : Gun
    {
        private const int STRIKE_BULLETS_AT_A_TIME = 1;

        public Pistol(string name, int bulletsCount)
            : base(name, bulletsCount)
        {
        }

        public override int Fire()
        {
            if (this.BulletsCount < STRIKE_BULLETS_AT_A_TIME)
            {
                return 0;
            }

            this.BulletsCount -= STRIKE_BULLETS_AT_A_TIME;

            return STRIKE_BULLETS_AT_A_TIME;
        }
    }
}
