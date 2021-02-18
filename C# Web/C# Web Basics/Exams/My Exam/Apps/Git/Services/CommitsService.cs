using Git.Data;
using Git.ViewModels.Commits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Git.Services
{
    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext db;

        public CommitsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(AddCommitInputModel model)
        {
            var repository = this.db.Repositories.FirstOrDefault(x => x.Id == model.RepositoryId);

            if (repository != null)
            {
                Commit commit = new Commit
                {
                    RepositoryId = model.RepositoryId,
                    CreatedOn = DateTime.UtcNow,
                    Description = model.Description,
                    CreatorId = model.CreatorId,
                };

                this.db.Commits.Add(commit);
            }

            this.db.SaveChanges();
        }

        public IEnumerable<CommitViewModel> GetAll(string userId)
        {
            var commits = this.db.Commits.Where(x => x.CreatorId == userId)
                .Select(x => new CommitViewModel
                {
                    CreatedOn = x.CreatedOn,
                    Description = x.Description,
                    RepositoryName = x.Repository.Name,
                    Id = x.Id
                }).ToList();

            return commits;
        }

        public void DeleteCommit(string id, string userId)
        {
            var commit = this.db.Commits.FirstOrDefault(x => x.Id == id);

            if (commit != null && commit.CreatorId == userId)
            {
                this.db.Commits.Remove(commit);
            }

            this.db.SaveChanges();
        }
    }
}
