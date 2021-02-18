namespace MXGP.Repositories.Models
{
    using MXGP.Models.Races.Contracts;
    using MXGP.Repositories.Contracts.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class RaceRepository : IRepository<IRace>
    {
        private readonly IList<IRace> races;

        public RaceRepository()
        {
            this.races = new List<IRace>();
        }

        public void Add(IRace race) => this.races.Add(race);

        public IReadOnlyCollection<IRace> GetAll() => this.races.ToList();

        public IRace GetByName(string name) => this.races.FirstOrDefault(x => x.Name == name);

        public bool Remove(IRace rider) => this.races.Remove(rider);
    }
}
