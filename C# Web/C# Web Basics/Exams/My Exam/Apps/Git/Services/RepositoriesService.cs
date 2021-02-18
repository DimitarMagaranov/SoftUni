using Git.Data;
using Git.ViewModels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Git.Services
{
    public class RepositoriesService : IRepositoriesService
    {
        private readonly ApplicationDbContext db;

        public RepositoriesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateRepository(AddRepositoryInputModel input)
        {
            var repositoryToAdd = new Repository
            {
                CreatedOn = DateTime.UtcNow,
                Name = input.Name,
                OwnerId = input.OwnerId
            };

            if (input.RepositoryType == "Public")
            {
                repositoryToAdd.IsPublic = true;
            }
            else
            {
                repositoryToAdd.IsPublic = false;
            }

            this.db.Repositories.Add(repositoryToAdd);

            this.db.SaveChanges();
        }

        public IEnumerable<RepositoryViewModel> GetAll()
        {
            var repositories = this.db.Repositories
                .Where(x => x.IsPublic == true)
                .Select(x => new RepositoryViewModel
            {
                Name = x.Name,
                Owner = x.Owner.Username,
                CreatedOn = x.CreatedOn,
                CommitsCount = x.Commits.Count(),
                RepositoryId = x.Id
            }).ToList();

            return repositories;
        }

        public Repository GetRepository(string id)
        {
            var repository = this.db.Repositories.FirstOrDefault(x => x.Id == id);

            return repository;
        }
    }
}
