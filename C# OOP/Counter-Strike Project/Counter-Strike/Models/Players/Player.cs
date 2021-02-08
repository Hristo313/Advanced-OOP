namespace Counter_Strike.Models.Players
{
    using Counter_Strike.Models.Guns;
    using Counter_Strike.Models.Guns.Contracts;
    using Counter_Strike.Models.Players.Contracts;
    using Counter_Strike.Utilities.Messages;
    using System;
    using System.Text;

    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private int armor;
        private IGun gun;

        protected Player(string username, int health, int armor, IGun gun)
        {
            this.Username = username;
            this.Health = health;
            this.Armor = armor;
            this.Gun = gun;
        }

        public string Username
        {
            get
            {
                return this.username;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerName);
                }

                this.username = value;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerHealth);
                }

                this.health = value;
            }
        }

        public int Armor
        {
            get
            {
                return this.armor;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerArmor);
                }

                this.armor = value;
            }
        }

        public bool IsAlive
            => this.Health > 0;

        public IGun Gun
        {
            get
            {
                return this.gun;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGun);
                }

                this.gun = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}: {this.Username}")
              .AppendLine($"--Health: {this.Health}")
              .AppendLine($"--Armor: {this.Armor}")
              .AppendLine($"-- Gun: {this.Gun.Name}");

            return sb.ToString().TrimEnd();
        }

        public void TakeDamage(int points)
        {
            if (this.Armor == 0)
            {
                DecreaseHealth(points);
            }
            else
            {
                if (this.Armor - points <= 0)
                {
                    points -= this.Armor;
                    this.Armor = 0;

                    DecreaseHealth(points);
                }
                else
                {
                    this.Armor -= points;
                }
            }
        }

        private void DecreaseHealth(int points)
        {
            if (this.Health - points <= 0)
            {
                this.Health = 0;
            }
            else
            {
                this.Health -= points;
            }
        }
    }
}
