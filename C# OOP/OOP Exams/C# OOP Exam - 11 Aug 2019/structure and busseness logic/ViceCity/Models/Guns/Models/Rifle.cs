using System;

namespace ViceCity.Models.Guns.Models
{
    public class Rifle : Gun
    {
        private const int bulletsPerFire = 5;
        private const int initialBulletsPerBarrel = 50;
        private const int initialTotalBullets = 500;

        public Rifle(string name)
            : base(name, initialBulletsPerBarrel, initialTotalBullets)
        {
        }

        public override int Fire()
        {
            if (this.BulletsPerBarrel - bulletsPerFire <= 0 && this.TotalBullets > 0)
            {
                this.BulletsPerBarrel -= bulletsPerFire;
                this.BulletsPerBarrel = initialBulletsPerBarrel;
                this.TotalBullets -= initialBulletsPerBarrel;
                return bulletsPerFire;
            }

            if (this.CanFire == true)
            {
                this.BulletsPerBarrel -= bulletsPerFire;
                return bulletsPerFire;
            }

            return 0;
        }
    }
}
