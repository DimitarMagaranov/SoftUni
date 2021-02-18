using System;
using System.Collections.Generic;
using System.Text;

namespace Git.ViewModels.Commits
{
    public class AddCommitInputModel
    {
        public string Description { get; set; }

        public DateTime CreatedOn => DateTime.UtcNow;

        public string CreatorId { get; set; }

        public string RepositoryId { get; set; }

        public string RepositoryName { get; set; }
    }
}
