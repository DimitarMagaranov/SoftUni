namespace MXGP.Repositories.Models
{
    using MXGP.Models.Riders.Contracts;
    using MXGP.Repositories.Contracts.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class RiderRepository : IRepository<IRider>
    {
        private readonly IList<IRider> riders;

        public RiderRepository()
        {
            this.riders = new List<IRider>();
        }

        public void Add(IRider rider) => this.riders.Add(rider);

        public IReadOnlyCollection<IRider> GetAll() => this.riders.ToList();

        public IRider GetByName(string name) => this.riders.FirstOrDefault(x => x.Name == name);

        public bool Remove(IRider rider) => this.riders.Remove(rider);
    }
}
