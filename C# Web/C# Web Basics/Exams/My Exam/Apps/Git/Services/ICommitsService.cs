using Git.ViewModels.Commits;
using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Services
{
    public interface ICommitsService
    {
        void Create(AddCommitInputModel model);

        IEnumerable<CommitViewModel> GetAll(string userId);

        void DeleteCommit(string id, string userId);
    }
}
