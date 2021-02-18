using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Repositories.Models
{
    public class GunRepository : IRepository<IGun>
    {
        private List<IGun> guns;

        public GunRepository()
        {
            this.guns = new List<IGun>();
        }

        public IReadOnlyCollection<IGun> Models => this.guns;

        public void Add(IGun model)
        {
            if (this.guns.Any(x => x.Name == model.Name) == false)
            {
                this.guns.Add(model);
            }
        }

        public IGun Find(string name)
        {
            IGun gun = this.guns.FirstOrDefault(x => x.Name == name);

            if (gun != null)
            {
                return gun;
            }

            return null;
        }

        public bool Remove(IGun model)
        {
            IGun gun = this.guns.FirstOrDefault(x => x.Name == model.Name);

            if (gun != null)
            {
                this.guns.Remove(gun);
                return true;
            }

            return false;
        }
    }

}
