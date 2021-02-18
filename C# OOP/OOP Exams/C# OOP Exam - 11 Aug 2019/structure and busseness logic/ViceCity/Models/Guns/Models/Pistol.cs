namespace ViceCity.Models.Guns.Models
{
    public class Pistol : Gun
    {
        private const int bulletsPerFire = 1;
        private const int initialBulletsPerBarrel = 10;
        private const int initialTotalBullets = 100;

        public Pistol(string name)
            : base(name, initialBulletsPerBarrel, initialTotalBullets)
        {
        }

        public override int Fire()
        {
            if (this.BulletsPerBarrel - bulletsPerFire <= 0 && this.TotalBullets > 0)
            {
                this.BulletsPerBarrel--;
                this.BulletsPerBarrel = initialBulletsPerBarrel;
                this.TotalBullets -= initialBulletsPerBarrel;
                return bulletsPerFire;
            }

            if (this.CanFire == true)
            {
                this.BulletsPerBarrel--;
                return bulletsPerFire;
            }

            return 0;
        }
    }
}
