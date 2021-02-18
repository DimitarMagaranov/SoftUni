namespace MXGP.Repositories
{
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Repositories.Contracts.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class MotorcycleRepository : IRepository<IMotorcycle>
    {
        private readonly IList<IMotorcycle> motorcycles;

        public MotorcycleRepository()
        {
            this.motorcycles = new List<IMotorcycle>();
        }

        public void Add(IMotorcycle motorcycle) => this.motorcycles.Add(motorcycle);

        public IReadOnlyCollection<IMotorcycle> GetAll() => this.motorcycles.ToList();

        public IMotorcycle GetByName(string model) => this.motorcycles.FirstOrDefault(x => x.Model == model);

        public bool Remove(IMotorcycle motorcycle) => this.motorcycles.Remove(motorcycle);
    }
}
